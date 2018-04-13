using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;

namespace Jobber.SmartAssistant.Features.GetNextVisit
{
    public class GetNextVisitIntentDefinition : IIntentDefinition
    {
        //FR-12.1: Getting information on next job
        //FR-12.2: Requesting information on next job with a note
        //FR-12.3: Requesting information on next job with notes
        //FR-12.4: Requesting information on next job with no note
        //FR-12.5: Requesting information on next job when there is no next job

        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetNextVisit)
                .TriggerOn("What's next?")
                .TriggerOn("Whats next?")
                .TriggerOn("What's my next visit?")
                .TriggerOn("Whats my next visit?")
                .TriggerOn("What is my next visit?")
                .TriggerOn("What is the next visit?")
                .TriggerOn("What is my next job?")
                .TriggerOn("What's my next job?")
                .TriggerOn("When is my next job?")
                .TriggerOn("When's my next job?")
                .TriggerOn("When is my next visit?")
                .TriggerOn("When's my next visit?")
                .TriggerOn("What do I have next?")
                .TriggerOn("What is next job?")
                .TriggerOn("What is next?")
                .TriggerOn("Next visit")
                .TriggerOn("Tell me next visit")
                .TriggerOn("Tell me my next job.")
                .TriggerOn("Tell me my next visit")
                .TriggerOn("Tell me my next visit today")
                .TriggerOn("Tell me my next job today")
                .TriggerOn("What is my next visit today?")
                .TriggerOn("What is my next job today?")
                .TriggerOn("What do I do next?")
                .TriggerOn("What job do I have next?")
                .TriggerOn("Can you tell me about my next job?")
                .TriggerOn("Can you tell me about my next visit?")
                .TriggerOn("Can you tell me a bit about my next visit?")
                .TriggerOn("Get my next visit.")
                .TriggerOn("Get next visit.")
                .TriggerOn("Can you get my next visit?")
                .TriggerOn("Can you get information about my next visit?")
                .TriggerOn("Can you get info about my next visit?")
                .TriggerOn("Can you get me details about my next job?")
                .FulfillWithWebhook()
                .Build();
        }
    }
}