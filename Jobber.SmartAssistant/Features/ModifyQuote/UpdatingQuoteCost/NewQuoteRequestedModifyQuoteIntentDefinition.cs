using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.ModifyQuote.UpdatingQuoteCost
{
    public class NewQuoteRequestedModifyQuoteIntentDefinition : IIntentDefinition
    {
        //FR-3.6: Specifying the new valid quote cash value
        //FR-3.7: Specifying an invalid new quote cash value
        
        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.NewQuoteRequestedModifyQuote)
                .RequiresContext(Constants.Contexts.QuoteDetailsSet)
                .TriggerOn($"[{Entity.Any}:{Constants.Variables.ServiceName}:Mowing]")
                .TriggerOn($"Could you please change " +
                           $"[{Entity.Any}:{Constants.Variables.ServiceName}:Mowing] to " +
                           $"$[{Entity.Number}:{Constants.Variables.Price}:20]")
                .TriggerOn($"Update " +
                           $"[{Entity.Any}:{Constants.Variables.ServiceName}:Mowing] to " +
                           $"$[{Entity.Number}:{Constants.Variables.Price}:20]")
                .TriggerOn($"Change " +
                           $"[{Entity.Any}:{Constants.Variables.ServiceName}:Mowing] to " +
                           $"$[{Entity.Number}:{Constants.Variables.Price}:20]")
                .TriggerOn($"Modify " +
                           $"[{Entity.Any}:{Constants.Variables.ServiceName}:Mowing] to " +
                           $"$[{Entity.Number}:{Constants.Variables.Price}:20]")
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.ServiceName, Entity.Any)
                    .WithPrompt("What is the name of the service?")
                )
                .RequireParameter(ParameterBuilder.Of(Constants.Variables.Price, Entity.Number)
                    .WithPrompt("What cost would you like to update it to?")
                    .WithPrompt("What cost price do you want me to update to?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}