using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class DescriptionRequestedCreateJobintentDefintion : IIntentDefinition
    {
        // FR-2.4: Specifying the description for a new job
        // FR-2.5: Specifying a single date for a new job
        // FR-2.6: Specifying a date range for a new job
        // FR-2.7: Specifying an invalid date range for a new job
        // FR-2.8: Specifying an invalid date range consecutively  for a new job
        // FR-2.9: Specifying a valid time range of a single date new job
        // FR-2.10: Specifying a time range for a multi date new job
        // FR-2.11: Specifying an invalid time range for a new job
        // FR-2.12: Specifying an invalid time range consecutively for a new job
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.DescritptionRequestedCreateJob)
                .RequiresContext(Constants.Contexts.CreateJobClientSet)
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.JobDescription}:Mowing the lawn]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.JobDescription, Entity.Any)
                    .WithPrompt("What is the description of the job?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.Date, Entity.DateTime)
                    .WithPrompt("What day is the job?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}