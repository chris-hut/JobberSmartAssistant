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
               .TriggerOn("Get revenue from last week")
               .TriggerOn("Get revenue from last month")
               .TriggerOn("Get revenue from last year")
               .TriggerOn("How much money we made")
               .TriggerOn("How much money we made last week")
               .TriggerOn("How much money we made last month")
               .TriggerOn("How much money we made last year")
               .TriggerOn("How much were we paid")
               .TriggerOn("How much were we paid last week")
               .TriggerOn("How much were we paid last month")
               .TriggerOn("How much were we paid last year")
               .FulfillWithWebhook()
               .Build();
        }
    }
}
