using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using Jobber.SmartAssistant.Features.CreateJob;
using Jobber.SmartAssistant.GoogleMaps;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAssignedVisitsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetAssignedVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
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
                .Speech($"You don't have any assigned visits today.")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildVisitFoundResponse(Visit visit)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech(BuildResponseFrom(visit))
                .WithMessage(BuildGoogleCardFrom(visit))
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse buildMultipleVisitsFoundResponse(VisitsCollections visits)
        {
            StringBuilder sb = new StringBuilder();
            FulfillmentResponseBuilder res = FulfillmentResponseBuilder.Create();
            foreach (Visit visit in visits.Visits)
            {
                res.Speech(BuildResponseFrom(visit));
                res.WithMessage(BuildGoogleCardFrom(visit));
            }  
            return res
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static string BuildResponseFrom(Visit visit)
        {
            if (string.IsNullOrEmpty(visit.Description))
            {
                return $"Visit {visit.Title}";
            }
            return $"Visit {visit.Title}, {visit.Description}.";
        }
        
        private static GoogleCardMessage BuildGoogleCardFrom(Visit visit)
        {
            var mapImage = GoogleMapsHelper.GetStaticMapLinkFor(visit.MyProperty.MapAddress);
            var mapLink = GoogleMapsHelper.GetGoogleMapsLinkFor(visit.MyProperty.MapAddress);

            if (string.IsNullOrEmpty(visit.Description))
            {
                return GoogleCardBuilder.Create()
                    .Title($"Visit {visit.Title}")
                    .Content("There is no description for this visit")
                    .Image(mapImage, "Map of visit location.")
                    .WithButton("Open Map", mapLink)
                    .Build();
            }
            return GoogleCardBuilder.Create()
                .Title($"Visit {visit.Title}")
                .Content(visit.Description)
                .Image(mapImage, "Map of visit location.")
                .WithButton("Open Map", mapLink)
                .Build();
        }
    }
}