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
                .RequiresContext(Constants.Contexts.QuoteDetailsRequested)
                .TriggerOn($"The quote is for [{Entity.Any}:{Constants.Variables.ClientName}:John]")
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.ClientName}:John]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ClientName, Entity.Any)
                    .WithPrompt("Who is the quote for?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ServiceNames, Entity.Any)
                    .WithPrompt("What services did the quote contain?")
                    .IsListParameter()
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}