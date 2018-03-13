using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Fulfillment;

namespace Jobber.SmartAssistant
{
    public class JobberIntentFulfiller : IIntentFulfiller
    {
        public Task<FullfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, Authentication authentication)
        {
            throw new System.NotImplementedException();
        }
    }
}