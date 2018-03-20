using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;


namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetJobsIntentFullfiller : IJobberIntentFulfiller
    {

        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetJobs);
        }
        
        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Your jobs today are lawn mowing, laundry")
                .Build();
        }
    }
}