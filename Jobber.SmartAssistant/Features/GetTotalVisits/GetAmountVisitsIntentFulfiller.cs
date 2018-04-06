using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.GetTotalVisits
{
    public class GetAmountVisitsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetAmountVisits);
        }
        
        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            var userId = fulfillmentRequest.GetCurrentUserId();
            var visits = await jobberClient.GetTodayAssignedVisitsAsync(userId);
            
            switch (visits.Count)
            {
                case 0:
                    return BuildNoVisitResponse();
                case 1:
                    return BuildVisitFoundResponse(visits.Visits.First());
                default:
                    return buildMultipleVisitsFoundResponse(visits);
            }
        }

        private static FulfillmentResponse BuildNoVisitResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Your day looks clear today")
                .Build();
        }

        private static FulfillmentResponse BuildVisitFoundResponse(Visit visit) 
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have one visit today.")
                .Build();
        }

        private static FulfillmentResponse buildMultipleVisitsFoundResponse(VisitsCollections visits)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {visits.Count} visits today.")
                .Build();
        }
    }
}