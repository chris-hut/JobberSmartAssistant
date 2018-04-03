using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.EasterEggs
{
    public class WhoAreYouIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.WhoAreYou)
                .TriggerOn("Who are you?")
                .TriggerOn("What are you?")
                .TriggerOn("What am I talking to?")
                .TriggerOn("Who am I talking to?")
                .TriggerOn("Who exactly am I talking to?")
                .RespondsWith("I'm just your friendly neighbourhood OctopusApp!")
                .Build();
        }
    }
}