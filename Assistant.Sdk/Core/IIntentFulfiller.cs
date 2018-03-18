using System.Threading.Tasks;
using DialogFlow.Sdk.Models.Fulfillment;

namespace Assistant.Sdk.Core
{
    public interface IIntentFulfiller
    {
        Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest);
    }
}