using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Jobber.Sdk
{
    public class JobberServiceFactory
    {
        public IJobberService CreateDialogFlowService(JobberConfig jobberConfig)
        {
            var httpClient = BuildAuthenticatingHttpClientFrom(jobberConfig);
            return RestService.For<IJobberService>(httpClient);
        }

        private static HttpClient BuildAuthenticatingHttpClientFrom(JobberConfig jobberConfig)
        {
            return new HttpClient(new AuthenticatingHttpClientHandler(jobberConfig.ApiKey))
            {
                BaseAddress = new Uri(jobberConfig.BaseApiUrl)
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
}