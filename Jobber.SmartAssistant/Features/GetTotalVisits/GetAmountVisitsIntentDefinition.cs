using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetTotalVisits
{
    public class GetAmountVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetAmountVisits)
                .TriggerOn("How many visits do I have?")
                .TriggerOn("How many visits do I have today?")
                .TriggerOn("How many sites do I need to visit today?")
                .TriggerOn("How many sites do I need to visit?")
                .TriggerOn("How many jobs do I have today?")
                .TriggerOn("How many jobs do I have?")
                .TriggerOn("Could you let me know how many places I need to go to today?")
                .TriggerOn("Could you let me know how many jobs I have?")
                .TriggerOn("Could you let me know how many visits I have?")
                .TriggerOn("Could you let me know how many visits I have today?")
                .TriggerOn("Can you let me know how many jobs I have?")
                .TriggerOn("Get todays visits")
                .FulfillWithWebhook()
                .Build();
        }   
    }
}