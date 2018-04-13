using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetTotalVisits
{
    public class GetAmountVisitsIntentDefinition : IIntentDefinition
    {
        //FR-9.1: Getting the amount of jobs assigned for the day
        //FR-9.2: Requesting for the amount of jobs assigned to them for the day when there isn’t any
        //FR-9.3: Requesting for the amount of jobs assigned to them for the day when there is only one
        //FR-9.4: Requesting for the amount of jobs assigned to them for the day when there is multiple

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
                .TriggerOn("Tell me how many visits I have today.")
                .TriggerOn("Tell me number of visits today")
                .TriggerOn("Tell me how many jobs today")
                .TriggerOn("Tell me how many visits today")
                .TriggerOn("What is the number of visits today")
                .TriggerOn("What is the number of jobs today")
                .TriggerOn("How much work do I have today")
                .TriggerOn("How much work do I have")
                .TriggerOn("How much work today")
                .TriggerOn("How many jobs today")
                .TriggerOn("How many visits today")
                .TriggerOn("Can you let me know how many jobs I have?")
                .TriggerOn("Get todays visits")
                .FulfillWithWebhook()
                .Build();
        }   
    }
}