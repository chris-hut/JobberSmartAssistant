using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.EasterEggs
{
    public class WhatDoYouDoIntent : IIntentDefinition
    {
        public Intent DefineIntent()
        {
            var response = "Hi, I'm Jobber's Smart Assistant. I live inside the " +
                           "Google Assistant and listen to your requests. When you " +
                           "ask me something I wait for DialogFlow to interpret what " +
                           "you said and then I look up what you're asking for in Jobber." +
                           "Based on what Jobber says I'll try my best to answer your question.";
                
            return IntentBuilder.For(Constants.Intents.WhatDoYouDo)
                .TriggerOn("What do you do?")
                .TriggerOn("What are you?")
                .TriggerOn("How do you work?")
                .TriggerOn("How does this work?")
                .RespondsWith(response)
                .Build();
        }
    }
}