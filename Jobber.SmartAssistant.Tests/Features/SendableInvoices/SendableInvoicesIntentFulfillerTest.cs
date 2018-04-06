using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.SendableInvoices;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.SendableInvoices
{
    [TestFixture]
    public class SendableInvoicesIntentFulfillerTest
    {
        [TestCase]
        public async Task TestNoSendableInvoices()
        {
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsDraftInvoices(new List<Invoice>())
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.SendableInvoices)
                .Build();

            var fulfiller = new SendableInvoicesIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("Looks like you have no invoices that need to be sent!");
        }

        [TestCase]
        public async Task TestSingleSendableInvoices()
        {
            var Invoices = Enumerable.Range(0, 1).Select(x => new Invoice()).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsDraftInvoices(Invoices)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.SendableInvoices)
                .Build();

            var fulfiller = new SendableInvoicesIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("There is one invoice ready to be sent.");
        }

        [TestCase]
        public async Task TestMultipleSendableInvoices()
        {
            var Invoices = Enumerable.Range(0, 2).Select(x => new Invoice()).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsDraftInvoices(Invoices)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.SendableInvoices)
                .Build();

            var fulfiller = new SendableInvoicesIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("There are 2 invoices ready to be sent.");
        }

    }
}
