using System.Linq;
using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetAmountOfJobsIntentFulfiller : IJobberIntentFulfiller
    { 
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetAmountOfJobs);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            var jobs = await jobberClient.GetJobsAsync();
            
            // Need to check if jobs date are within today
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {jobs.Count} jobs today.")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}