using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote.RequestingQuoteDetails
{
    public class DetailsRequestedModifyQuoteIntentDefinition : IIntentDefinition
    {
        //FR-3.3: Specifying an existing quote to be changed
        //FR-3.4: Specifying a non-existing quote to be changed
        //FR-3.5: Specifying a vague quote to be changed
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.DetailsRequestedModifyQuote)
                .RequiresContext(Constants.Contexts.QuoteDetailsRequested)
                .TriggerOn($"The quote is for [{Entity.Any}:{Constants.Variables.ClientName}:John]")
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.ClientName}:John]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ClientName, Entity.Any)
                    .WithPrompt("Who is the quote for?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ServiceName, Entity.Any)
                    .WithPrompt("Can you give me a service in the quote?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}