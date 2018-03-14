using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant.Features.Tennis
{
    public class TennisIntentDefinition : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            return IntentBuilder.For("tennis")
                .TriggerOn("I like tennis")
                .TriggerOn("I like tennis @sys.number:amount:10 out of 10")
                .RequireParameter(ParameterBuilder.Of("amount", "@sys.number")
                    .WithPrompt("How much do you like tennis out of 10?")
                    .WithPrompt("On a scale of 1 to 10, how much do you like tennis?")
                )
                .FulfillWithWebhook()
                .Build();
        }
    }
}