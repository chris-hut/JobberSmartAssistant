using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.UnassignedVisits
{
    public class UnassignedVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.UnassignedVisits)
                .TriggerOn("How many visits do I still need to assign today?")
                .FulfillWithWebhook()
                .Build();
        }
    }
}
