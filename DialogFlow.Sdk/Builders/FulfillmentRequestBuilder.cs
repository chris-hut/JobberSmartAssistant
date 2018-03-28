using System.Collections.Generic;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Fulfillment;

namespace DialogFlow.Sdk.Builders
{
    public class FulfillmentRequestBuilder
    {
        private readonly FulfillmentRequest _fulfillmentRequest;

        private FulfillmentRequestBuilder(string name)
        {
            _fulfillmentRequest = new FulfillmentRequest
            {
                ConversationResult = new ConversationResult {ActionName = name}
            };
        }

        public static FulfillmentRequestBuilder For(string name)
        {
            return new FulfillmentRequestBuilder(name);
        }

        public FulfillmentRequestBuilder WithParameter(string parameterName, object parameterValue)
        {
            _fulfillmentRequest.ConversationResult.Parameters[parameterName] = parameterName.ToString();
            return this;
        }

        public FulfillmentRequestBuilder WithContextParamter(string contextName, string parameterName, object parameterValue)
        {
            _fulfillmentRequest.ConversationResult.Contexts.Add(new Context
            {
                Name = contextName,
                Parameters = new Dictionary<string, string>
                {
                    { parameterName, parameterValue.ToString() }
                }
            });
            return this;
        }

        public FulfillmentRequest Build()
        {
            return _fulfillmentRequest;
        }
    }
}