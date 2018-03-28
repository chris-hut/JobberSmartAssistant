using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Rest;

using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Jobber.SmartAssistant.Core
{
    public class JobberSmartAssistantIntentFulfiller : IIntentFulfiller
    {
        private readonly JobberClientFactory _jobberClientFactory;
        private readonly IList<IJobberIntentFulfiller> _jobberIntentFulfillers;
        
        public JobberSmartAssistantIntentFulfiller()
        {
            _jobberClientFactory = new JobberClientFactory();   
            _jobberIntentFulfillers = new List<IJobberIntentFulfiller> { new DefaultJobberIntentFulfiller() };
        }

        public JobberSmartAssistantIntentFulfiller WithJobberIntentFulfiller(IJobberIntentFulfiller jobberIntentFulfiller)
        {
            _jobberIntentFulfillers.Insert(0, jobberIntentFulfiller);
            return this;
        }
        
        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest)
        {
            var jobberServer = _jobberClientFactory.CreateJobberClient(new JobberConfig
            {
                ApiKey = fulfillmentRequest.OriginalRequest.Data.User.AccessToken
            });
            return await GetJobberIntentFulfillerFor(fulfillmentRequest).FulfillAsync(fulfillmentRequest, jobberServer);
        }

        private IJobberIntentFulfiller GetJobberIntentFulfillerFor(FulfillmentRequest fulfillmentRequest)
        {
            return _jobberIntentFulfillers.First(f => f.CanFulfill(fulfillmentRequest));
        }
        
    }
}