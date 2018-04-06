using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.ConvertableQuotes;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.ConvertibleQuotes
{
    [TestFixture]
    public class ConvertibleQuotesIntentFulfillerTest
    {
        [TestCase]
        public async Task TestNoConvertibleQuotes()
        {
            var Quotes = Enumerable.Range(0, 1).Select(x => new Quote() { ApprovedAt = 0, Client = new Client() { Name = "John Doe" } }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsQuotesAsync(Quotes)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ConvertibleQuotes)
                .Build();

            var fulfiller = new ConvertibleQuoteIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("Looks like there aren't any quotes that can be converted.");
        }

        [TestCase]
        public async Task TestSingleConvertibleQuotes()
        {
            var Quotes = Enumerable.Range(0, 1).Select(x => new Quote() { ApprovedAt = 1, Client = new Client() { Name = "John Doe"} }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsQuotesAsync(Quotes)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ConvertibleQuotes)
                .Build();

            var fulfiller = new ConvertibleQuoteIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("You have one quote that can be converted for John Doe.");
        }

        [TestCase]
        public async Task TestMultipleConvertibleQuotes()
        {
            var Quotes = Enumerable.Range(0, 2).Select(x => new Quote() { ApprovedAt = 1}).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsQuotesAsync(Quotes)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ConvertibleQuotes)
                .Build();

            var fulfiller = new ConvertibleQuoteIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("There are 2 quotes ready to be converted into jobs.");
        }

    }
}
