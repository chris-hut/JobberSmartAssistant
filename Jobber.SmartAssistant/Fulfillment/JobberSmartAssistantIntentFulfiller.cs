using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;

namespace Jobber.SmartAssistant.Fulfillment
{
    public class JobberSmartAssistantIntentFulfiller : IIntentFulfiller
    {
        private readonly JobberServiceFactory _jobberServiceFactory;
        private readonly IList<IJobberIntentFulfiller> _jobberIntentFulfillers;
        
        public JobberSmartAssistantIntentFulfiller()
        {
            _jobberServiceFactory = new JobberServiceFactory();   
            _jobberIntentFulfillers = new List<IJobberIntentFulfiller> { new DefaultJobberIntentFulfiller() };
        }

        public JobberSmartAssistantIntentFulfiller WithJobberIntentFulfiller(IJobberIntentFulfiller jobberIntentFulfiller)
        {
            _jobberIntentFulfillers.Insert(0, jobberIntentFulfiller);
            return this;
        }
        
        public async Task<FullfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, Authentication authentication)
        {
            var jobberServer = _jobberServiceFactory.CreateDialogFlowService(new JobberConfig
            {
                ApiKey = authentication.AuthenticationString
            });

            return await GetJobberIntentFulfillerFor(fulfillmentRequest).FulfillAsync(fulfillmentRequest, jobberServer);
        }

        private IJobberIntentFulfiller GetJobberIntentFulfillerFor(FulfillmentRequest fulfillmentRequest)
        {
            return _jobberIntentFulfillers.First(f => f.CanFulfill(fulfillmentRequest));
        }
        
    }
}