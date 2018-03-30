using System;
using System.Linq;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Fulfillment;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Extensions
{
    public static class FulfillmentResponseExtensions
    {
        public static FulfillmentResponse AssertResponseSpeech(
            this FulfillmentResponse fulfillmentResponse, string expectedResponseSpeech)
        {
            Assert.AreEqual(fulfillmentResponse.Speech, expectedResponseSpeech);
            return fulfillmentResponse;
        }

        public static FulfillmentResponse AssertContainsOutgoingContext(
            this FulfillmentResponse fulfillmentResponse, string contextName)
        {
            Assert.IsTrue(fulfillmentResponse.ContextOut.Any(c => c.Name.ToLower() == contextName.ToLower()));
            return fulfillmentResponse;
        }

        public static FulfillmentResponse AssertOutgoingContextHasLifespanOf(
            this FulfillmentResponse fulfillmentResponse, string contextName, int lifespan)
        {
            var context = fulfillmentResponse.GetContext(contextName);
            Assert.AreEqual(lifespan, context.Lifespan);
            return fulfillmentResponse;
        }
        
        public static FulfillmentResponse AssertOutgoingContextHasParameter(
            this FulfillmentResponse fulfillmentResponse, string contextName, string parameterName)
        {
            var context = fulfillmentResponse.GetContext(contextName);
            Assert.IsTrue(context.Parameters.ContainsKey(parameterName));
            return fulfillmentResponse;
        }
    }
}