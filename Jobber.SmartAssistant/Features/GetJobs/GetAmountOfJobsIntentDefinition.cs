using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetAmountOfJobsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetAmountOfJobs)
                .TriggerOn("Get amount of jobs assigned to me for today.")
                .TriggerOn("Get number of my jobs for today.")
                .TriggerOn("How many jobs do I have today.")
                .FulfillWithWebhook()
                .Build();
        }
        
        
    }
}