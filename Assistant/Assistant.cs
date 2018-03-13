using System.IO;
using System.Threading.Tasks;
using Assistant.Core;
using DialogFlow.Sdk.Fulfillment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Assistant
{
    public class Assistant
    {
        private readonly IIntentRegistry _intentRegistry;
        private readonly IIntentSynchronizer _intentSynchronizer;
        private readonly IAuthenticationExtractor _authenticationExtractor;
        private readonly IIntentFulfiller _intentFulfiller;
        private readonly IWebHostBuilder _webHostBuilder;

        public Assistant(
            IIntentRegistry intentRegistry, 
            IIntentSynchronizer intentSynchronizer, 
            IAuthenticationExtractor authenticationExtractor, 
            IIntentFulfiller intentFulfiller,
            IWebHostBuilder webHostBuilder
        ) {
            _intentRegistry = intentRegistry;
            _intentSynchronizer = intentSynchronizer;
            _authenticationExtractor = authenticationExtractor;
            _intentFulfiller = intentFulfiller;
            _webHostBuilder = webHostBuilder;
        }

        public static AssistantBuilder Builder()
        {
            return new AssistantBuilder();
        }

        public async Task RunAsync()
        {
            await SynchronizeLatestIntentsAsync();
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
            var authentication = _authenticationExtractor.ExtractAuthenticationFrom(httpContext.Request);
            var fulfillmentRequest = ExtractFulfillmentRequestFrom(httpContext.Request);
            var fulfillmentResponse = await _intentFulfiller.FulfillAsync(fulfillmentRequest, authentication);
            var rawFulfillmentResponse = JsonConvert.SerializeObject(fulfillmentRequest);

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