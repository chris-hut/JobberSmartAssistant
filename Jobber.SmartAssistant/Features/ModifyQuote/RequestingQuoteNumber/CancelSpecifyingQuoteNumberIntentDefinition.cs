using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote.RequestingQuoteNumber
{
    public class CancelSpecifyingQuoteNumberIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.CancelRequestFor(Constants.Intents.CancelQuoteNumberRequestedModifyQuote)
                .RequiresContext(Constants.Contexts.QuoteNumberRequested)
                .RespondsWith("Okay. I won't change any quotes.")
                .Build();
        }
    }
}