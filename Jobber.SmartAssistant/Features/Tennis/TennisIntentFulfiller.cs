using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.Tennis
{
    public class TennisIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction("tennis");
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            var amount = int.Parse(fulfillmentRequest.ConversationResult.Parameters["amount"]);

            return FulfillmentResponseBuilder.Create()
                .Speech($"Wow. You like tennis {amount} out of 10")
                .WithContext(ContextBuilder.For("TENNIS_REQUESTED").WithParameter("amount", amount.ToString()))
                .Build();
        }
    }
}