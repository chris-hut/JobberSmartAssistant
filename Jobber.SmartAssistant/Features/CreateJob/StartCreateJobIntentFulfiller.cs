using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using DialogFlow.Sdk.Intents;
using Jobber.Sdk;
using Jobber.Sdk.Responses;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class StartCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.StartCreateJob);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            var clientName = fulfillmentRequest.GetParameter(Constants.ClientNameVar);
            var matchingClients = await jobberService.GetClientsAsync(clientName);

            if (DoesContainClients(matchingClients))
            {
                return BuildClientFoundResponse(matchingClients.Clients.First().Id);
            }

            return BuildClientNotFoundResponse(clientName);
        }

        private bool DoesContainClients(ClientsResponse clientsResponse)
        {
            return clientsResponse.Clients.Any();
        }
        
        private FulfillmentResponse BuildClientFoundResponse(int clientId)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Okay! Can you describe the job?")
                .WithContext(
                    ContextBuilder.For(Constants.StartCreateJob)
                        .Lifespan(1)
                        .WithParameter(Constants.ClientIdVar, clientId.ToString())
                )
                .Build();
        }

        private FulfillmentResponse BuildClientNotFoundResponse(string clientName)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Sorry I dont know who {clientName} is.")
                .Build();
        }
    }
}