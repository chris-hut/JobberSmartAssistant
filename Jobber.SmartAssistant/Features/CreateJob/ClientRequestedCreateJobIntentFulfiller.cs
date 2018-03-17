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
    public class ClientRequestedCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.ClientRequestedCreateJob);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            var clientName = fulfillmentRequest.GetParameter(Constants.Variables.ClientName);
            var matchingClients = await jobberService.GetClientsAsync(clientName);

            switch (matchingClients.Count)
            {
               case 0:
                   return BuildClientNotFoundResponse(clientName);
               case 1:
                   return BuildClientFoundResponse(matchingClients.Clients.First());
               default:
                   return BuildMultipleClientsFound(clientName);
            }
        }

        private static FulfillmentResponse BuildClientFoundResponse(Client client)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Okay! What are you going to do for {client.Name}?")
                .WithContext(
                    ContextBuilder.For(Constants.Contexts.CreateJobClientSet)
                        .WithParameter(Constants.Variables.ClientId, client.Id.ToString())
                )
                .Build();
        }
        
        private static FulfillmentResponse BuildMultipleClientsFound(string clientName)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"There a few people who have a smiliar name to {clientName}, can you be a bit more specific?")
                .WithContext(ContextBuilder.For(Constants.Contexts.CreateJobClientRePrompted))    
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