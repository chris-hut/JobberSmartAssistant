using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class ClientRequestedCreateJobIntentDefinition : IIntentDefinition
    {
        // FR-2.2: Starting a create job request
        // FR-2.3: Specifying the client for a new job
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.ClientRequestedCreateJob)
                .RequiresContext(Constants.Contexts.CreateJobClientRequested)
                .TriggerOn($"The job is for [{Entity.Any}:{Constants.Variables.ClientName}:John Appleseed]")
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.ClientName}:John Appleseed]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ClientName, Entity.Any)
                    .WithPrompt("Who is this job for?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}