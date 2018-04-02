using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetNextVisit
{
    public class GetNextVisitIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetNextVisit)
                .TriggerOn("What is my next visit?")
                .TriggerOn("Get my next visit.")
                .FulfillWithWebhook()
                .Build();
        }
    }
}