using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ConvertableQuotes
{
    class ConvertibleQuoteIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.ConvertibleQuotes)
               .TriggerOn("How many quotes are ready to be turned into jobs?")
               .TriggerOn("How many quotes are ready?")
               .TriggerOn("How many quotes are approved?")
               .TriggerOn("How many quotes can become jobs?")
               .TriggerOn("Ready quotes")
               .TriggerOn("Convertible quotes")
               .FulfillWithWebhook()
               .Build();
        }
    }
}
