using System.Threading.Tasks;
using DialogFlow.Sdk.Fulfillment;

namespace Assistant.Sdk.Core
{
    public interface IIntentFulfiller
    {
        Task<FullfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, Authentication authentication);
    }
}