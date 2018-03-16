using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class ClientSetCreateJobintentDefintion : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.ClientSetCreateJob)
                .RequiresContext(Constants.StartCreateJob)
                .TriggerOn($"[{Entity.Any}:{Constants.DescriptionVar}:Mowing the lawn]")
                .RequireParameter(ParameterBuilder.Of(Constants.DescriptionVar, Entity.Any)
                    .WithPrompt("What is the description of the job?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.DateVar, Entity.DateTime)
                    .WithPrompt("What day is the job?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}