using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetCompletableVisits
{
    public class DontGetCompletableDetailsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.NoRequestFor(Constants.Intents.DontGetCompletableVisitsDetails)
                .RequiresContext(Constants.Contexts.AskedIfUserWantsCompletableDetails)
                .RespondsWith("Ok, see you later.")
                .RespondsWith("Ok, goodbye.")
                .Build();
        }
    }
}