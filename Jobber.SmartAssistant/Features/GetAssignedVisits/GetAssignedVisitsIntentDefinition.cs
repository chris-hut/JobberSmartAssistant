using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAssignedVisitsIntentDefinition : IIntentDefinition
    {
        //FR-10.1: Getting the jobs assigned for the day
        //FR-10.2: Requesting the jobs assigned for the day
        //FR-10.3: Requesting jobs assigned for the day when there aren’t any

        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetAssignedVisits)
                .TriggerOn("Can you tell me what visits I have today?")
                .TriggerOn("Can you tell me my visits for the day?")
                .TriggerOn("Can you tell what my visits are for the day?")
                .TriggerOn("Could you tell what my visits are for the day?")
                .TriggerOn("Can you tell me what visits I have for the day?")
                .TriggerOn("Can you tell me what visits I have?")
                .TriggerOn("Could you tell me what visits I have?")
                .TriggerOn("Get visits assigned to me for today.")
                .TriggerOn("Get my visits for today.")
                .TriggerOn("Get my visits for the day.")
                .TriggerOn("What are my visits today.")
                .TriggerOn("What visits do I have today?")
                .TriggerOn("What are my jobs today?")
                .TriggerOn("Tell me what are my visits today.")
                .TriggerOn("Tell me my visits today.")
                .TriggerOn("Tell my my jobs today")
                .TriggerOn("What do I do today.")
                .TriggerOn("What do I have to do today.")
                .TriggerOn("Get visits")
                .TriggerOn("Get today's visits")
                .TriggerOn("Get my visits")
                .TriggerOn("Get my visits for the day")
                .TriggerOn("Could you get my visits?")
                .TriggerOn("Get jobs for today")
                .TriggerOn("Get my jobs for today")
                .TriggerOn("Can you get my jobs for today")
                .FulfillWithWebhook()
                .Build();
        }
    }
}