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