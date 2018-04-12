using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.EasterEggs
{
    public class LaughIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.Laughing)
                .TriggerOn("lol")
                .TriggerOn("haha")
                .TriggerOn("youre funny")
                .RespondsWith("xD")
                .Build();
        }
    }
}