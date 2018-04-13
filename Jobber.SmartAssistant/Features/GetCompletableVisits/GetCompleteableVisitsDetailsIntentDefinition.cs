using System.Collections.Generic;
using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetCompletableVisits
{
    public class GetCompleteableVisitsDetailsIntentDefinition : IIntentDefinition
    {
        //FR-4.4: Requesting for the list of visits that should be marked complete when it exists
        //FR-4.6: Invalid responds to list visits that should be marked complete
        public Intent DefineIntent()
        {
            return IntentBuilder.YesRequestFor(Constants.Intents.GetCompletableVisitsDetails)
                .RequiresContext(Constants.Contexts.AskedIfUserWantsCompletableDetails)
                .FulfillWithWebhook()
                .Build();
        }
    }
}