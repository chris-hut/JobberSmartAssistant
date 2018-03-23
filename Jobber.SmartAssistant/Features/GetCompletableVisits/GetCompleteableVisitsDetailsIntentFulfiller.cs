using System;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.GetCompletableVisits
{
    public class GetCompleteableVisitsDetailsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetCompletableVisitsDetails);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var todaysVisits = await jobberClient.GetTodaysVisitsAsync();

            switch (todaysVisits.NumCompletable)
            {
                case 1:
                    return BuildSingleVisitResponseFor(todaysVisits);
                default:
                    return BuildMultipleVisitsResponseFor(todaysVisits);
            }
        }

        private static FulfillmentResponse BuildSingleVisitResponseFor(VisitsCollections visitsCollection)
        {
            var visit = visitsCollection.CompletableVisits.First();

            return FulfillmentResponseBuilder.Create()
                .Speech(BuildDescriptionFor(visit))
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildMultipleVisitsResponseFor(VisitsCollections visitsCollection)
        {
            var visitDescriptions = visitsCollection.CompletableVisits.Select(BuildDescriptionFor);
            var joinedDescriptions = String.Join(" ", visitDescriptions);

            return FulfillmentResponseBuilder.Create()
                .Speech(joinedDescriptions)
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static string BuildDescriptionFor(Visit visit)
        {
            var commaSeperateWorkerNames = String.Join(", ", visit.AssignedTo.Select(a => a.Name));
            return $"{commaSeperateWorkerNames} finished doing work for {visit.MyClient.FirstName}.";
        }
    }
}