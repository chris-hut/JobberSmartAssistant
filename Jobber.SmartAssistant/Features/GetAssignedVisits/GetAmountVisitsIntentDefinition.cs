using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAmountVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetAmountVisits)
                .TriggerOn("How many visits do I have today?")
                .TriggerOn("How many work for me today.")
                .FulfillWithWebhook()
                .Build();
        }   
    }
}