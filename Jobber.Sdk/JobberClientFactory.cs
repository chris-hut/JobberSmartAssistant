using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jobber.Sdk.Rest;
using Refit;

namespace Jobber.Sdk
{
    public class JobberClientFactory
    {
        public IJobberClient CreateJobberClient(JobberConfig jobberConfig)
        {
            var httpClient = BuildJobberHttpClientFrom(jobberConfig);
            var jobberApi = RestService.For<IJobberApi>(httpClient);
            return new JobberClient(jobberApi);
        }

        private static HttpClient BuildJobberHttpClientFrom(JobberConfig jobberConfig)
        {
            return new HttpClient(new JobberHttpClient(jobberConfig.ApiKey))
            {
                BaseAddress = new Uri(jobberConfig.BaseApiUrl)
            };
        }
    }

    public class JobberHttpClient : HttpClientHandler
    {
        private readonly string _apiToken;

        public JobberHttpClient(string apiToken)
        {
            _apiToken = apiToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-API-VERSION", "5.0.0");
            request.Headers.Add("Authorization", $"Bearer {_apiToken}");
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}