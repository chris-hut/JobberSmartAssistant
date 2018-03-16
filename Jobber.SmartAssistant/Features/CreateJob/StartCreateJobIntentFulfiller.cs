using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using DialogFlow.Sdk.Intents;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class StartCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.StartCreateJob);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Can you describe the job?")
                .WithContext(
                    ContextBuilder.For(Constants.StartCreateJob)
                        .Lifespan(1)
                        .WithParameter(Constants.ClientVar, "0")
                )
                .Build();
        }
    }
}