using System;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;

namespace DialogFlow.Sdk.Builders
{
    public class FulfillmentResponseBuilder
    {
        private readonly FulfillmentResponse _fulfillmentResponse;

        private FulfillmentResponseBuilder()
        {
            _fulfillmentResponse = new FulfillmentResponse();
        }

        public static FulfillmentResponseBuilder Create()
        {
            return new FulfillmentResponseBuilder();
        }

        public FulfillmentResponseBuilder Speech(string speech)
        {
            _fulfillmentResponse.Speech = speech;
            _fulfillmentResponse.Messages.Add(new SpeechMessage
            {
                Speech = speech
            });
            
            return this;
        }

        public FulfillmentResponseBuilder DisplayText(string displayText)
        {
            _fulfillmentResponse.DisplayText = displayText;
            return this;
        }

        public FulfillmentResponseBuilder WithMessage(IMessage message)
        {
            _fulfillmentResponse.Messages.Add(message);
            return this;
        }
        
        public FulfillmentResponseBuilder WithContext(ContextBuilder contextBuilder)
        {
            _fulfillmentResponse.ContextOut.Add(contextBuilder.Build());
            return this;
        }
        
        public FulfillmentResponse Build()
        {
            if (String.IsNullOrEmpty(_fulfillmentResponse.DisplayText))
            {
                _fulfillmentResponse.DisplayText = _fulfillmentResponse.Speech;
            }
            
            return _fulfillmentResponse;
        }
    }
}