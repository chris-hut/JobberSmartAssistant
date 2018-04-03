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
                .TriggerOn("Can you tell me how many invoices are ready to be sent?")
                .TriggerOn("Could you tell me how many invoices are ready to be sent?")
                .TriggerOn("Get ready invoices")
                .TriggerOn("Can you tell me many invoices can be sent?")
                .TriggerOn("Could you tell me many invoices can be sent?")
                .TriggerOn("How many invoices can be sent?")
                .TriggerOn("How many invoices need to be sent?")
                .TriggerOn("How many invoices need to be sent out?")
                .TriggerOn("Ready invoices?")
                .TriggerOn("Sendable invoices")
                .TriggerOn("Issuable invoices")
                .FulfillWithWebhook()
                .Build();
        
        }
    }
}
