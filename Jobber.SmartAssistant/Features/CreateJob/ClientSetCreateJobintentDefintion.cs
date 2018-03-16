using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class ClientSetCreateJobintentDefintion : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.CLIENT_SET_CREATE_JOB)
                .RequiresContext(Constants.START_CREATE_JOB)
                .TriggerOn($"[{Entity.Any}:{Constants.DESCRIPTION_VAR}:Mowing the lawn.]")
                .RequireParameter(ParameterBuilder.Of(Constants.DESCRIPTION_VAR, Entity.Any)
                    .WithPrompt("What is the description of the job?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.DATE_VAR, Entity.DateTime)
                    .WithPrompt("What day is the job?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}