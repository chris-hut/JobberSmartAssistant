using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class ClientSetCreateJobintentDefintion : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.ClientSetCreateJob)
                .RequiresContext(Constants.Intents.StartCreateJob)
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.Description}:Mowing the lawn]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.Description, Entity.Any)
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