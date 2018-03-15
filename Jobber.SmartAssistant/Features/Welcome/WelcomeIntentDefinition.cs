using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.Welcome
{
    public class WelcomeIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For("Welcome Intent")
                .RequiresEvent(Events.WELCOME_EVENT)
                .TriggerOn($"Can I talk to {Constants.ASSISTANT_NAME}")
                .TriggerOn("I need to organize my jobs")
                .TriggerOn("I want to manage my jobs")
                .RespondsWith("How can I help?")
                .Build();
        }
    }
}