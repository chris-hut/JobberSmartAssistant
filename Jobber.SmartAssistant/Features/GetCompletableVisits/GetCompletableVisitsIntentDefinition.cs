using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetCompletableVisits
{
    public class GetCompletableVisitsIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetCompletableVisits)
                .TriggerOn("How many visits can be marked as complete?")
                .TriggerOn("Completable visits")
                .TriggerOn("Get completable visits")
                .TriggerOn("Could you get completable visits?")
                .TriggerOn("How many visits can I complete")
                .TriggerOn("How many visits need to be completed")
                .TriggerOn("How many visits are ready for completion")
                .TriggerOn("How many visits are done")
                .TriggerOn("Tell me how many visits are done")
                .TriggerOn("Can you tell me how many visits are done?")
                .TriggerOn("Can you tell me how many visits can be marked as completed?")
                .TriggerOn("Could you tell me how many visits are done?")
                .FulfillWithWebhook()
                .Build();
        }
    }
}