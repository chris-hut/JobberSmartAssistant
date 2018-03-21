using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetLengthWorkDayIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetLengthWorkDay);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            var jobs = await jobberClient.GetJobsAsync();
            
            // Need to add length calculation here
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have 5 hours of work today")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}