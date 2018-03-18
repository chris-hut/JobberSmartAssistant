using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.FavoriteNumber
{
    public class FavoriteNumberIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For("FAVORITE_NUMBER")
                .TriggerOn("Guess what my favorite number is?")
                .TriggerOn("Ask me what is my favorite number.")
                .RequireParameter(
                    ParameterBuilder.Of("num", Entity.Number)
                        .WithPrompt("What is your favorite number?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}