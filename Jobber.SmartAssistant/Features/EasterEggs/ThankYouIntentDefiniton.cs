using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.EasterEggs
{
    public class ThankYouIntentDefiniton : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For("THANK_YOU_EASTER_EGG")
                .TriggerOn("Thanks")
                .TriggerOn("Thank you")
                .TriggerOn("Thanks a lot")
                .RespondsWith("No thanks.")
                .Build();
        }
    }
}