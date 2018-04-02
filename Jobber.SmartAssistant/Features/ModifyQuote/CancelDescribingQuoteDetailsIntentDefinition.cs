using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote
{
    public class CancelDescribingQuoteDetailsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.CancelRequestFor(Constants.Intents.CancelDescribingModifyQuote)
                .RequiresContext(Constants.Contexts.QuoteDetailsRequested)
                .TriggerOn("Stop modifying quote")
                .RespondsWith("Okay I won't change anything. Talk to you later.")
                .Build();
        }
    }
}