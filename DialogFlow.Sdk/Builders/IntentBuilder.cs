using System.Collections.Generic;
using DialogFlow.Sdk.Intents;

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

        public IntentBuilder RequiresContext(string contextName)
        {
            _intent.Contexts.Add(contextName);
            return this;
        }
        
        public IntentBuilder TriggerOn(string triggerStatement)
        {
            _intent.UserSays.Add(new TriggerStatementParser().Parse(triggerStatement));
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

        public IntentBuilder RespondsWith(string responseString)
        {
            GetCurrentResponse().Messages.Add(new SpeechMessage
            {
                Speech = responseString
            });
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