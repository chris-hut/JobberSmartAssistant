using System.Collections.Generic;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Intents;
using DialogFlow.Sdk.Models.Messages;

namespace DialogFlow.Sdk.Builders
{
    public class IntentBuilder
    {
        private readonly Intent _intent;

        private IntentBuilder(string name)
        {
            _intent = new Intent
            {
                Name = name,
                Responses = new List<IntentResponse>
                {
                    new IntentResponse
                    {
                        Name = name,
                        Action = name
                    }
                }
            };
        }

        public static IntentBuilder For(string name)
        {
            return new IntentBuilder(name);
        }

        public static IntentBuilder YesRequestFor(string name)
        {
            return IntentBuilder.For(name)
                .TriggerOn("Yes")
                .TriggerOn("Confirm")
                .TriggerOn("Ok")
                .TriggerOn("Of course")
                .TriggerOn("Sure")
                .TriggerOn("I don't mind")
                .TriggerOn("Yaaaas")
                .TriggerOn("That's correct")
                .TriggerOn("I agree")
                .TriggerOn("Do it")
                .TriggerOn("Exactly")
                .TriggerOn("Sounds good");
        }

        public static IntentBuilder NoRequestFor(string name)
        {
            return IntentBuilder.For(name)
                .TriggerOn("No")
                .TriggerOn("I don't want that")
                .TriggerOn("I disagree")
                .TriggerOn("I don't think so")
                .TriggerOn("not really")
                .TriggerOn("not interested")
                .TriggerOn("definitely not")
                .TriggerOn("duh no");
        }
        
        public static IntentBuilder CancelRequestFor(string name)
        {
            return IntentBuilder.For(name)
                .TriggerOn("Stop")
                .TriggerOn("Cancel")
                .TriggerOn("Nevermind")
                .TriggerOn("Don't worry about it")
                .TriggerOn("I'll do it later");
        }

        public IntentBuilder RequiresContext(string contextName)
        {
            _intent.Contexts.Add(contextName);
            return this;
        }

        public IntentBuilder RequiresEvent(string eventName)
        {
            _intent.Events.Add(new Event
            {
                Name = eventName
            });
            return this;
        }
        
        public IntentBuilder TriggerOn(string triggerStatement)
        {
            _intent.UserSays.Add(new TriggerStatementParser().Parse(triggerStatement));
            return this;
        }
        
        public IntentBuilder TriggerOnFallback()
        {
            _intent.FallbackIntent = true;
            return this;
        }

        public IntentBuilder WithPriority(int priority)
        {
            _intent.Priority = priority;
            return this;
        }

        public IntentBuilder RequireParameter(ParameterBuilder parameterBuilder)
        {
            GetCurrentResponse().Parameters.Add(parameterBuilder.Build());
            return this;
        }
        
        public IntentBuilder WithOptionalParameter(ParameterBuilder parameterBuilder)
        {
            var parameter = parameterBuilder.Build();
            parameter.Required = false;
            GetCurrentResponse().Parameters.Add(parameter);
            return this;
        }

        public IntentBuilder RespondsWith(string responseString)
        {
            GetCurrentResponse().Messages.Add(new SpeechMessage
            {
                Speech = responseString
            });
            return this;
        }

        public IntentBuilder CreatesContext(ContextBuilder contextBuilder)
        {
            GetCurrentResponse().AffectedContexts.Add(contextBuilder.Build());
            return this;
        }

        public IntentBuilder FulfillWithWebhook()
        {
            _intent.WebhookUsed = true;
            return this;
        }

        public Intent Build()
        {
            return _intent;
        }

        private IntentResponse GetCurrentResponse()
        {
            return _intent.Responses[0];
        }
    }
}