using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote
{
    public class DetailsRequestedModifyQuoteIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.DetailsRequestedModifyQuote)
                .TriggerOn($"The quote is for [{Entity.Any}:{Constants.Variables.ClientName}:John] on [{Entity.DateTime}:{Constants.Variables.Date}:friday]")
                .FulfillWithWebhook()
                .Build();
        }
    }
}