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
                .TriggerOn("How long is my work today?")
                .TriggerOn("How much work do I have today?")
                .FulfillWithWebhook()
                .Build();
        }
    }
}