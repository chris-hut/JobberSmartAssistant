using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.GetRevenue;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.GetRevenue
{
    [TestFixture]
    public class GetRevenueIntentFulfillerTest
    {
        [TestCase]
        public async Task TestDefaultTimeUnitRevenue()
        {
            var Transactions = Enumerable.Range(0, 1).Select(x => new Transaction() { Amount = "100.00", Type = "Invoice" }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsRangedTransactions(Transactions)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetRevenue)
                .Build();

            var fulfiller = new GetRevenueIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("We made $100.00 last week");
        }

        [TestCase]
        public async Task TestTimeUnitRevenue()
        {
            var Transactions = Enumerable.Range(0, 2).Select(x => new Transaction() { Amount = "100.25", Type = "Invoice" }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsRangedTransactions(Transactions)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetRevenue)
                .WithParameter(Constants.Variables.TimeUnitOriginal, "in last March")
                .Build();

            var fulfiller = new GetRevenueIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("We made $200.50 in last March");
        }
    }
}
