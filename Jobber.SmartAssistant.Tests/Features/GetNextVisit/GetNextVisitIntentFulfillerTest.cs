using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Extensions;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.GetNextVisit;
using Jobber.SmartAssistant.Features.UnassignedVisits;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.GetNextVisit
{
    [TestFixture]
    public class GetNextVisitIntentFulfillerTest
    {
        [TestCase]
        public async Task TestGetNextVisit()
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

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetNextVisit)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetNextVisitIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            Assert.IsTrue(response.Speech.Contains("Test visit"));   
        }

        [TestCase]
        public async Task TestNextNoVisit()
        {
            int userId = 1;
            var visits = Enumerable.Empty<Visit>().ToList();
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsAssignedForToday(visits, userId)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetNextVisit)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetNextVisitIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            Assert.IsTrue(response.Speech.Contains($"Your remaining day looks clear"));    
        }
        
    }
}