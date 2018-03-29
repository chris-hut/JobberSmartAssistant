using DialogFlow.Sdk.Models.Fulfillment;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Extensions
{
    public static class FulfillmentResponseExtensions
    {
        public static void AssertResponseSpeech(this FulfillmentResponse fulfillmentResponse, string expectedResponseSpeech)
        {
            Assert.AreEqual(fulfillmentResponse.Speech, expectedResponseSpeech);
        }
    }
}