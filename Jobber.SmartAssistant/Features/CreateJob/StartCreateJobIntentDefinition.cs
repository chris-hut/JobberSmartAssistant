using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class StartCreateJobIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.StartCreateJob)
                .TriggerOn("I want to create a job")
                .TriggerOn("Can you help me with setting up a job?")
                .TriggerOn("I want to make a job")
                .TriggerOn("Create a job")
                .TriggerOn("New job")
                .TriggerOn("Can you make a job?")
                .TriggerOn("can you create a job?")
                .TriggerOn($"I want to add a job for [{Entity.Any}:{Constants.ClientVar}:John Appleseed]")
                .RequireParameter(ParameterBuilder.Of(Constants.ClientVar, Entity.Any)
                    .WithPrompt("Who is this job for?")
                    .WithPrompt("Who needs the work done?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}