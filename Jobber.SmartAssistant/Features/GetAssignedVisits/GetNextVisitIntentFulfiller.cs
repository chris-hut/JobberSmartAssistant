using System;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
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
                .Speech($"Your next visit is {visits.Visits.First().Description}")
                .MarkEndOfAssistantConversation()
                .Build(); 
        }
    }
}