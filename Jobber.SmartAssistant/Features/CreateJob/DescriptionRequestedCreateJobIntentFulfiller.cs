using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class DescriptionRequestedCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.DescritptionRequestedCreateJob);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Okay I created the job for you!")
                .Build();
        }
    }
}