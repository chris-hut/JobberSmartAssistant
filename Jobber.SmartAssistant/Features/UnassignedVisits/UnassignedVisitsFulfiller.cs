using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.UnassignedVisits
{
    public class UnassignedVisitsFulfiller : IJobberIntentFulfiller
    {

        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.UnassignedVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {



            return FulfillmentResponseBuilder.Create()
                .Speech("Can you describe the job?")
                .Build();
        }
    }
}
