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
        public async Task TestIfNoClientMatches()
        {
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsClients(new List<Client>())
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ClientRequestedCreateJob)
                .WithParameter(Constants.Variables.ClientName, "John")
                .Build();
            
            var fulfiller = new ClientRequestedCreateJobIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient);
            
            response.AssertResponseSpeech("Sorry I dont know who John is.");
        }

        [TestCase]
        public async Task TestIfOneClientMatches()
        {
            var john = new Client
            {
                Name = "John Smith",
                MyProperties = new List<Properties>
                {
                    new Properties
                    {
                        MapAddress = "Rogers Place, Edmonton"
                    }
                }
            };
            
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsClients(new List<Client> { john })
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ClientRequestedCreateJob)
                .WithParameter(Constants.Variables.ClientName, "John")
                .Build();
            
            var fulfiller = new ClientRequestedCreateJobIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient);

            response
                .AssertResponseSpeech("Okay! What are you going to do for John Smith?")
                .AssertContainsOutgoingContext(Constants.Contexts.CreateJobClientSet)
                .AssertOutgoingContextHasLifespanOf(Constants.Contexts.CreateJobClientSet, 1);
        }

        [TestCase]
        public async Task TestIfMultipleClientsMatch()
        {
            var johnSmith = new Client { Name = "John Smith" };
            var johnAppleseed = new Client { Name = "John Appleseed" };
            
            var mockJobberClient = MockJobberClientBuilder.Create()
                .ReturnsClients(new List<Client> { johnSmith, johnAppleseed })
                .Build();

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ClientRequestedCreateJob)
                .WithParameter(Constants.Variables.ClientName, "John")
                .Build();
            
            var fulfiller = new ClientRequestedCreateJobIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, mockJobberClient);

            response
                .AssertResponseSpeech("There a few people who have a smiliar name to John, can you be a bit more specific?")
                .AssertContainsOutgoingContext(Constants.Contexts.CreateJobClientRequested)
                .AssertOutgoingContextHasLifespanOf(Constants.Contexts.CreateJobClientRequested, 1);
        }
    }
}