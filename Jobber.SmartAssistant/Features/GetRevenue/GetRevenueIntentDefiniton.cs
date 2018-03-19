using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetRevenue
{
    public class GetRevenueIntentDefiniton : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetRevenue)
               .TriggerOn("Get revenue")
               .TriggerOn("How much money we made")
               .FulfillWithWebhook()
               .Build();
        }
    }
}
