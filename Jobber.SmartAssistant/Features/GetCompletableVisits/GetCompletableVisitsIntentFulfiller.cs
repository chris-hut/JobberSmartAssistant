using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.GetCompletableVisits
{
    public class GetCompletableVisitsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetCompletableVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var todaysVisits = await jobberClient.GetTodaysVisitsAsync();

            switch (todaysVisits.NumCompletable)
            {
                case 0:
                    return BuildNoVisitsCompletableResponse();
                case 1:
                    return BuildSingleVisitsCompletableResponse();
                default:
                    return BuildMultipleCompleteableVisitsResponse(todaysVisits.NumCompletable);
            }
        }
        
        private static FulfillmentResponse BuildMultipleCompleteableVisitsResponse(int numCompletableVisits)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {numCompletableVisits} visits that are ready to be completed.")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildSingleVisitsCompletableResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("You have one visit that are ready to be completed.")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildNoVisitsCompletableResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("No visits need to be completed right now.")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}