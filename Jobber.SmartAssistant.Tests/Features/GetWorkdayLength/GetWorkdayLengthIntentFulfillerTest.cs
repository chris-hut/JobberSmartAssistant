using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Extensions;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.GetWorkdayLength;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.GetWorkdayLength
{
    [TestFixture]
    public class GetWorkdayLengthIntentFulfillerTest
    {
        [TestCase]
        public async Task TestGetLengthNoWork()
        {
            long userId = 1;
            var visits = Enumerable.Empty<Visit>();
            
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsVisitsAssignedForToday(visits, userId)
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetLengthWorkday)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetLengthWorkdayIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            
            response.AssertResponseSpeech($"You have no work today.");
        }

        [TestCase]
        public async Task TestGetLengthWork()
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

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.GetLengthWorkday)
                .Build();
            fulfillmentRequest.UserId = userId;
            var fulfiller = new GetLengthWorkdayIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient.Object);
            Assert.IsTrue(response.Speech.Contains("Your work is"));
        }
    }
}