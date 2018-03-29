using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Features;
using Jobber.SmartAssistant.Features.CreateJob;
using Jobber.SmartAssistant.Tests.Extensions;
using Moq;
using NUnit.Framework;

namespace Jobber.SmartAssistant.Tests.Features.CreateJob
{
    [TestFixture]
    public class ClientRequestedCreateJobIntentFulfillerTests
    {
        [TestCase]
        public async Task TestIfNoClient()
        {
            var jobberClientMock = new Mock<IJobberClient>();
            jobberClientMock
                .Setup(j => j.GetClientsAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new ClientCollection());

            var jobberClient = jobberClientMock.Object;

            var fulfillmentRequest = FulfillmentRequestBuilder.Create(Constants.Intents.ClientRequestedCreateJob)
                .WithParameter(Constants.Variables.ClientName, "George")
                .Build();
            
            var fulfiller = new ClientRequestedCreateJobIntentFulfiller();
            var response = await fulfiller.FulfillAsync(fulfillmentRequest, jobberClient);
            
            response.AssertResponseSpeech("Sorry I dont know who George is.");
        }
    }
}