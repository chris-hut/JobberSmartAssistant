using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class StartCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.START_CREATE_JOB);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Can you describe the job?")
                .WithContext(ContextBuilder.For(Constants.START_CREATE_JOB).WithParameter(Constants.CLIENT_VAR, "0"))
                .Build();
        }
    }
}