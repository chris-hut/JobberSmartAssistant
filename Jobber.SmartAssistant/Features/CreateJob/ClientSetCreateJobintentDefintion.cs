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
                .FulfillWithWebhook()
                .Build();
        }
    }
}