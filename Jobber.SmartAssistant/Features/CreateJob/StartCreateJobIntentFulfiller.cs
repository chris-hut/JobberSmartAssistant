using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using DialogFlow.Sdk.Intents;
using Jobber.Sdk;
using Jobber.Sdk.Models;
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

            if (matchingClients.Count == 1)
            {
                return BuildClientFoundResponse(matchingClients.Clients.First());
            }
            else if (matchingClients.Count > 1)
            {
                return BuildMultipleClientsFound(clientName);
            }

            return BuildClientNotFoundResponse(clientName);
        }

        private static bool ContainsOnlyOneClient(ClientsResponse clientsResponse)
        {
            return clientsResponse.Clients.Any();
        }
        
        private static FulfillmentResponse BuildClientFoundResponse(Client client)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Okay! What are going to do for {client.Name}?")
                .WithContext(
                    ContextBuilder.For(Constants.StartCreateJob)
                        .Lifespan(1)
                        .WithParameter(Constants.ClientIdVar, client.Id.ToString())
                )
                .Build();
        }
        
        private static FulfillmentResponse BuildMultipleClientsFound(string clientName)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"I found multiple people with names similar to {clientName}. Could you be more specific next time?")
                .Build();
        }

        private static FulfillmentResponse BuildClientNotFoundResponse(string clientName)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Sorry I dont know who {clientName} is.")
                .Build();
        }
    }
}