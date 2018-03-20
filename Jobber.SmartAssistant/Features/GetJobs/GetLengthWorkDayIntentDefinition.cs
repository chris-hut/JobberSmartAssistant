using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetLengthWorkDayIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetLengthWorkDay)
                .TriggerOn("How long is my work today.")
                .TriggerOn("How long do I have work today.")
                .TriggerOn("How long are my jobs today.")
                .FulfillWithWebhook()
                .Build();
        }
    }
}