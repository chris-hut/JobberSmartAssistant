using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ConvertableQuotes
{
    public class ConvertibleQuoteIntentDefinition : IIntentDefinition
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
                .TriggerOn("Approved quotes")
                .TriggerOn("Get convertible quotes")
                .TriggerOn("Can you let me know how many quotes are ready to be turned into jobs?")
                .TriggerOn("I wonder how many quotes are approved")
                .FulfillWithWebhook()
                .Build();
        }
    }
}
