using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class StartCreateJobIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.START_CREATE_JOB)
                .TriggerOn("I want to create a job.")
                .TriggerOn("Can you help me with setting up a job?")
                .TriggerOn($"I want to add a job for [{Entity.Any}:{Constants.CLIENT_VAR}:John Appleseed].")
                .RequireParameter(ParameterBuilder.Of(Constants.CLIENT_VAR, Entity.Any)
                    .WithPrompt("How is this job for?")
                    .WithPrompt("Who needs the work done?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}