using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class DescriptionRequestedCreateJobintentDefintion : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.DescritptionRequestedCreateJob)
                .RequiresContext(Constants.Contexts.CreateJobClientSet)
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.JobDescription}:Mowing the lawn]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.JobDescription, Entity.Any)
                    .WithPrompt("What is the description of the job?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.JobDate, Entity.DateTime)
                    .WithPrompt("What day is the job?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}