using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.UnassignedVisits
{
    public class UnassignedVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.UnassignedVisits)
                .TriggerOn("How many visits do I still need to assign today?")
                .TriggerOn("How many visits do I still need to assign?")
                .TriggerOn("How many visits are unassigned today?")
                .TriggerOn("How many visits are unassigned?")
                .TriggerOn("Can you let me know how many visits I still need to assign today?")
                .TriggerOn("Can you let me know how many visits I need to assign today?")
                .TriggerOn("Can you tell me know how many visits I still need to assign today?")
                .TriggerOn("Unassigned visits for today")
                .TriggerOn("Unassigned visits")
                .TriggerOn("Get unassigned visits")
                .FulfillWithWebhook()
                .Build();
        }
    }
}
