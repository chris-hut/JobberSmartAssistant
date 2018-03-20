using System.Reflection.Metadata;
using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;


namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetJobsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetJobs)
                .TriggerOn("Get jobs assigned to me for today.")
                .TriggerOn("Get my jobs for today.")
                .TriggerOn("What are my jobs today.")
                .TriggerOn("What do I do today.")
                .FulfillWithWebhook()
                .Build();
        }
    }
}