using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.Fallback
{
    public class FallbackIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.Fallback)
                .TriggerOnFallback()
                .RespondsWith("I didn't get that. Can you say it again?")
                .RespondsWith("Can you say that again?")
                .RespondsWith("One more time?")
                .RespondsWith("I didn't quite get that.")
                .RespondsWith("One more time?")
                .Build();
        }
    }
}