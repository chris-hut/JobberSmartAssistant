using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
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
            
            Console.Write(response);
            response.AssertResponseSpeech($"You have no work today.");
        }
    }
    
    
    
}