using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetWorkdayLength
{
    public class GetLengthWorkdayIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetLengthWorkday)
                .TriggerOn("How long is my day today?")
                .TriggerOn("How long is my day")
                .TriggerOn("How much work do I have?")
                .TriggerOn("How long is my work today?")
                .TriggerOn("How much work today?")
                .TriggerOn("Tell me how much work I have today.")
                .TriggerOn("Tell me how long my day is.")
                .TriggerOn("Could you tell me how much work I have today.")
                .TriggerOn("What is the length of my workday?")
                .TriggerOn("Could you tell me how long my day is today?")
                .TriggerOn("Let me know how much work I have today")
                .TriggerOn("How much work do I have to do today?")
                .TriggerOn("How long is my workday?")
                .TriggerOn("How much work do I have today?")
                .FulfillWithWebhook()
                .Build();
        }
    }
}