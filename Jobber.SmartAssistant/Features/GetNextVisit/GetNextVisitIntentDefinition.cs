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
                .TriggerOn("What is my next job?")
                .TriggerOn("When is my next job?")
                .TriggerOn("When is my next visit?")
                .TriggerOn("What do I have next?")
                .TriggerOn("Can you tell me about my next job?")
                .TriggerOn("Can you tell me about my next visit?")
                .TriggerOn("Can you tell me a bit about my next visit?")
                .TriggerOn("Get my next visit.")
                .FulfillWithWebhook()
                .Build();
        }
    }
}