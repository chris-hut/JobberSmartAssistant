using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.EasterEggs
{
    public class NotWorkingIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.NotWorking)
                .TriggerOn("It's not working?")
                .TriggerOn("Something is broken")
                .TriggerOn("Nothing works")
                .TriggerOn("You're stupid")
                .RespondsWith("It's probably just a null pointer exception.")
                .Build();
        }
    }
}