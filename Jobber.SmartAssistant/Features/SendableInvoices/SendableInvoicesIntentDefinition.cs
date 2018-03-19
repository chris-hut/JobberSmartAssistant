using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.SendableInvoices
{
    public class SendableInvoicesIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.SendableInvoices)
               .TriggerOn("How many invoices are ready to be sent?")
               .TriggerOn("Ready invoices?")
               .TriggerOn("Sendable invoices")
               .TriggerOn("Issuable invoices")
               .FulfillWithWebhook()
               .Build();
        
        }
    }
}
