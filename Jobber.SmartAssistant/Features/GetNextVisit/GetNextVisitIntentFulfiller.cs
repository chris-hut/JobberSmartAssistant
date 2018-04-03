using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using Jobber.SmartAssistant.GoogleMaps;

namespace Jobber.SmartAssistant.Features.GetNextVisit
{
    public class GetNextVisitIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetNextVisit);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            var userId = fulfillmentRequest.GetCurrentUserId();
            var current_time = DateTime.Now.ToUnixTime();
            var visits = await jobberClient.GetTodayAssignedVisitsAsync(userId, current_time);
            if (visits.Count == 0)
            {
                return FulfillmentResponseBuilder.Create()
                    .Speech($"Your remaining day looks clear")
                    .MarkEndOfAssistantConversation()
                    .Build();    
            }
            return FulfillmentResponseBuilder.Create()
                .Speech(BuildResponseFrom(visits.Visits.First()))
                .WithMessage(BuildGoogleCardFrom(visits.Visits.First()))
                .MarkEndOfAssistantConversation()
                .Build(); 
        }

        private static string BuildResponseFrom(Visit visit)
        {
            float fromNow = visit.StartAt - DateTime.Now.ToUnixTime();
            int hoursFromNow = (int) Math.Floor(fromNow);
            int minutesFromNow = (int) ((fromNow - hoursFromNow) * 60);
            
            float length = visit.EndAt - visit.StartAt;
            float duration = (float) (length / 3600 / 100);
            int hours = (int) Math.Floor(duration);
            int minutes = (int) ((duration - hours) * 60);
            
            if (!visit.MyJob.Notes.Any())
            {
                return $"Next visit is {visit.Title}, {visit.Description}. " +
                       $"Visit location is {visit.MyProperty.MapAddress}. " +
                       $"Visit starts in {hoursFromNow} hours and {minutesFromNow} minutes. " +
                       $"Visit duration is {hours} hours and {minutes} minutes.";
            }
    
            StringBuilder sb = new StringBuilder();
            foreach (Note note in visit.MyJob.Notes)
            {
                sb.Append(note.Message);
            }
            return $"Next visit is {visit.Title}, {visit.Description}. " +
                   $"Visit location is {visit.MyProperty.MapAddress}. " +
                   $"Visit starts in {hoursFromNow} hours and {minutesFromNow} minutes. " +
                   $"Visit duration is {hours} hours and {minutes} minutes." +
                   $"Job notes are {sb.ToString()}.";
        }
        
        private static GoogleCardMessage BuildGoogleCardFrom(Visit visit)
        {
            var mapImage = GoogleMapsHelper.GetStaticMapLinkFor(visit.MyProperty.MapAddress);
            var mapLink = GoogleMapsHelper.GetGoogleMapsLinkFor(visit.MyProperty.MapAddress);
            return GoogleCardBuilder.Create()
                .Title($"Visit {visit.Title}")
                .Content(BuildResponseFrom(visit))
                .Image(mapImage, "Map of visit location.")
                .WithButton("Open Map", mapLink)
                .Build();
        }
    }
}