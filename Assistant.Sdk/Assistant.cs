using System;
using System.IO;
using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Assistant.Sdk
{
    public class Assistant
    {
        private readonly IIntentRegistry _intentRegistry;
        private readonly IIntentSynchronizer _intentSynchronizer;
        private readonly IAuthenticationExtractor _authenticationExtractor;
        private readonly IIntentFulfiller _intentFulfiller;
        private readonly ILogger _logger;
        private readonly IWebHostBuilder _webHostBuilder;

        public Assistant(
            IIntentRegistry intentRegistry, 
            IIntentSynchronizer intentSynchronizer, 
            IAuthenticationExtractor authenticationExtractor, 
            IIntentFulfiller intentFulfiller,
            ILogger logger,
            IWebHostBuilder webHostBuilder
        ) {
            _intentRegistry = intentRegistry;
            _intentSynchronizer = intentSynchronizer;
            _authenticationExtractor = authenticationExtractor;
            _intentFulfiller = intentFulfiller;
            _logger = logger;
            _webHostBuilder = webHostBuilder;
        }

        public static AssistantBuilder Builder()
        {
            return new AssistantBuilder();
        }

        public async Task RunAsync()
        {
            _logger.LogInfo("Synchronizing Intents.");
            await SynchronizeLatestIntentsAsync();
            _logger.LogInfo("Intent synchronization complete.");

            _logger.LogInfo("Launching fulfillment endpoint.");
            await LaunchFulfillmentWebServerAsync();
        }

        private async Task SynchronizeLatestIntentsAsync()
        {
            var intents = _intentRegistry.DefineIntents();
            await _intentSynchronizer.SynchronizeIntentsAsync(intents);
        }

        private async Task LaunchFulfillmentWebServerAsync()
        {
            await _webHostBuilder
                .Configure(b => b.Run(HandleWebRequestAsync))
                .Build()
                .RunAsync();
        }

        private async Task HandleWebRequestAsync(HttpContext httpContext)
        {
            if (IsRequestForFulfillment(httpContext.Request))
            {
                await TryToHandleFulfillmentRequestAsync(httpContext);
            }
            else
            {
                _logger.LogInfo("Received invalid request.");
                httpContext.Response.StatusCode = 404;
            }
        }

        private static bool IsRequestForFulfillment(HttpRequest httpRequest)
        {
            var strippedPath = httpRequest.Path.Value.TrimStart('/').TrimEnd('/').ToLower();
            return httpRequest.Method == "POST" && strippedPath == "fulfillment";
        }

        private async Task TryToHandleFulfillmentRequestAsync(HttpContext httpContext)
        {
            try
            {
                await HandleFulfillmentRequestAsync(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Encountered an exception [{ex.GetType().Name}: {ex.Message}] while handling request.");
                
                var response = FulfillmentResponseBuilder.Create()
                    .Speech("Sorry something went wrong. Try asking me again later.")
                    .Build();

                await WriteFulfillmentResponseAsync(response, httpContext);
            }
        }
        
        private async Task HandleFulfillmentRequestAsync(HttpContext httpContext)
        {
            var authentication = _authenticationExtractor.ExtractAuthenticationFrom(httpContext.Request);
            var fulfillmentRequest = ExtractFulfillmentRequestFrom(httpContext.Request);

            _logger.LogInfo("Fulfillment request recieved for intent with action: " +
                            $"{fulfillmentRequest.ConversationResult.ActionName} " +
                            $"and id: {fulfillmentRequest.Id}.");

            var fulfillmentResponse = await _intentFulfiller.FulfillAsync(fulfillmentRequest, authentication);
            await WriteFulfillmentResponseAsync(fulfillmentResponse, httpContext);
        }

        private static async Task WriteFulfillmentResponseAsync(FulfillmentResponse fulfillmentResponse, HttpContext httpContext)
        {
            var rawFulfillmentResponse = JsonConvert.SerializeObject(fulfillmentResponse);

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(rawFulfillmentResponse);
        }

        private static FulfillmentRequest ExtractFulfillmentRequestFrom(HttpRequest httpRequest)
        {
            using (var streamReader = new StreamReader(httpRequest.Body))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var jsonSeralizer = new JsonSerializer();
                return jsonSeralizer.Deserialize<FulfillmentRequest>(jsonTextReader);
            }
        }
    }
}