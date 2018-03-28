using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAssignedVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetAssignedVisits)
                .TriggerOn("Get visits assigned to me for today.")
                .TriggerOn("Get my visits for today.")
                .TriggerOn("What are my visits today.")
                .TriggerOn("What do I do today.")
                .FulfillWithWebhook()
                .Build();
        }
    }
}