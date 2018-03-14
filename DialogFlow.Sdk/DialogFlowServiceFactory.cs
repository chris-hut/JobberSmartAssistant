using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;

namespace DialogFlow.Sdk
{
    public class DialogFlowServiceFactory
    {
        private readonly HttpClient _httpClient;

        public DialogFlowServiceFactory(DialogFlowConfig dialogFlowConfig)
        {
            _httpClient = BuildAuthenticatingHttpClientFrom(dialogFlowConfig);
        }
     
        public IDialogFlowService CreateDialogFlowService()
        {
            return RestService.For<IDialogFlowService>(_httpClient);
        }

        private static HttpClient BuildAuthenticatingHttpClientFrom(DialogFlowConfig dialogFlowConfig)
        {
            return new HttpClient(new AuthenticatingHttpClientHandler(dialogFlowConfig.ApiKey))
            {
                BaseAddress = new Uri(dialogFlowConfig.BaseApiUrl)
            };
        }
    }

    public class AuthenticatingHttpClientHandler : HttpClientHandler
    {
        private readonly string _apiToken;

        public AuthenticatingHttpClientHandler(string apiToken)
        {
            _apiToken = apiToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", $"Bearer {_apiToken}");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}