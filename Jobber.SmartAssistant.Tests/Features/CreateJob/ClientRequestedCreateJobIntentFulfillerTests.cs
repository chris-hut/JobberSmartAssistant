using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.CreateJob;
using Jobber.SmartAssistant.Tests.Extensions;
using Jobber.SmartAssistant.Tests.Mocks;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.CreateJob
{
    [TestFixture]
    public class ClientRequestedCreateJobIntentFulfillerTests
    {
        [TestCase]
        public async Task TestIfNoClient()
        {
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsClients(new List<Client>())
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ClientRequestedCreateJob)
                .WithParameter(Constants.Variables.ClientName, "George")
                .Build();
            
            var fulfiller = new ClientRequestedCreateJobIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient);
            
            response.AssertResponseSpeech("Sorry I dont know who George is.");
        }
    }
}