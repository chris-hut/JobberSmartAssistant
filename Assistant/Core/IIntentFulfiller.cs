using System.Threading.Tasks;
using DialogFlow.Sdk.Fulfillment;

namespace Assistant.Core
{
    public interface IIntentFulfiller
    {
        Task<FullfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest);
    }
}