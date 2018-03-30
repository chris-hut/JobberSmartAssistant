using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote
{
    public class StartModifyQuoteIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.StartModifyQuote)
                .TriggerOn("Change a quote")
                .TriggerOn("Can you change a quote")
                .TriggerOn("I want to change a quote")
                .TriggerOn("Change quote")
                .TriggerOn("Modify quote")
                .TriggerOn("Update quote")
                .TriggerOn("I need to change a quote")
                .TriggerOn("Can you help me change a quote")
                .RespondsWith("Okay can you tell me a bit about the quote?")
                .CreatesContext(ContextBuilder.For(Constants.Contexts.QuoteDetailsRequested))
                .Build();
        }
    }
}