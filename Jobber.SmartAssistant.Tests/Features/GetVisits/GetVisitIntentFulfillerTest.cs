using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Extensions;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.GetAssignedVisits;
using Jobber.SmartAssistant.Features.GetTotalVisits;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.GetVisits
{
    [TestFixture]
    public class GetVisitIntentFulfillerTest
    {
        [TestCase]
        public async Task TestGetVisitsNoWork()
        {
            long userId = 1;
            var visits = Enumerable.Empty<Visit>();
            
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsAssignedForToday(visits, userId)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetAssignedVisits)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetAssignedVisitsIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            Assert.IsTrue(response.Speech.Contains($"You don't have any assigned visits today."));
        }

        [TestCase]
        public async Task TestGetVisitsWork()
        {
            int userId = 1;
            var start = (int) DateTime.Now.AddHours(2).ToUnixTime();
            var end = (int) DateTime.Now.AddHours(4).ToUnixTime();
            var note = $"Test visit";
            
            var visits = Enumerable.Range(0, 1).Select(x => new Visit()
            {
                StartAt = start,
                EndAt = end,
                Description = note,
                AssignedTo = new List<Assigned>() {new Assigned() {Id = userId}}, 
                Title = "Test visit"
            }).ToList();
            
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsAssignedForToday(visits, userId)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetAssignedVisits)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetAssignedVisitsIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            Assert.IsTrue(response.Speech.Contains($"Test visit"));
        }
    }
}