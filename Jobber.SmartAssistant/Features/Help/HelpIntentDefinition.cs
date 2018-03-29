using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.Help
{
    public class HelpIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.Help)
                .TriggerOn("What can you do.")
                .TriggerOn("What to do")
                .TriggerOn("How to use app")
                .TriggerOn("help")
                .FulfillWithWebhook()
                .Build();
        }
    }
}
