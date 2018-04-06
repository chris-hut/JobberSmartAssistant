using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.UnassignedVisits;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.UnassignedVisits
{
    [TestFixture]
    public class UnassignedVisitsIntentFulfillerTest
    {
        [TestCase]
        public async Task TestNoUnassignedVisits()
        {
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsForToday(new List<Visit>())
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.UnassignedVisits)
                .Build();

            var fulfiller = new UnassignedVisitsIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("There are no visits left to be assigned today!");
        }

        [TestCase]
        public async Task TestSingleUnassignedVisits()
        {
            var Visits = Enumerable.Range(0, 1).Select(x => new Visit() { AssignedTo = new List<Assigned>() }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsForToday(Visits)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.UnassignedVisits)
                .Build();

            var fulfiller = new UnassignedVisitsIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("You have 1 visit left to be assigned today.");
        }

        [TestCase]
        public async Task TestMultipleUnassignedVisits()
        {
            var Visits = Enumerable.Range(0, 2).Select(x => new Visit() { AssignedTo = new List<Assigned>() }).ToList();

            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsForToday(Visits)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.UnassignedVisits)
                .Build();

            var fulfiller = new UnassignedVisitsIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);

            response.AssertResponseSpeech("You have 2 unassigned visits for today.");
        }
    }
}
