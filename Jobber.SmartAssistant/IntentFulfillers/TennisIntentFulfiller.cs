using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using DialogFlow.Sdk.Intents;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.IntentFulfillers
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

    public class TennisIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For("tennis")
                .TriggerOn("I like tennis")
                .TriggerOn("I like tennis @sys.number:amount:10 out of 10")
                .RequireParameter(ParameterBuilder.Of("amount", "@sys.number")
                    .WithPrompt("How much do you like tennis out of 10?")
                    .WithPrompt("On a scale of 1 to 10, how much do you like tennis?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}