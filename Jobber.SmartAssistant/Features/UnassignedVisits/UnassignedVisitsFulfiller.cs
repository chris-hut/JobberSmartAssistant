using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.UnassignedVisits
{
    public class UnassignedVisitsFulfiller : IJobberIntentFulfiller
    {

        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.UnassignedVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {

            var unassignedVisits = await jobberService.GetClientsAsync();

            switch (unassignedVisits.Count)
            {
                case 0:
                    return BuildClientNotFoundResponse(clientName);
                case 1:
                    return BuildClientFoundResponse(matchingClients.Clients.First());
                default:
                    return BuildMultipleClientsFound(clientName);
            }
        }

        private static FulfillmentResponse BuildMultipleUnassignedVisitsFoundResponse(int unassignedVisits)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {unassignedVisits} unassigned visits for today.")
                .Build();
        }

        private static FulfillmentResponse BuildSingleUnassignedVisitsFoundResponse(int unassignedVisits)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have 1 visit left to be assigned today.")
                .Build();
        }

        private static FulfillmentResponse BuildClientNotFoundResponse(int unassginedVisits)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"There are no visits left to be assigned today!")
                .Build();
        }
    }
}
