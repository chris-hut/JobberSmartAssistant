using System;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.GetWorkdayLength
{
    public class GetLengthWorkdayIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetLengthWorkday);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var userId = fulfillmentRequest.GetCurrentUserId();
            var visits = await jobberClient.GetTodayAssignedVisitsAsync(userId);
            float length = 0;
            foreach (Visit visit in visits.Visits)
            {
                length += visit.EndAt - visit.StartAt;
            }
            float duration = (float) (length / 3600 / 100);
            int hours = (int) Math.Floor(duration);
            int minutes = (int) ((duration - hours) * 60);
            
            if (hours == 0)
            {
                return FulfillmentResponseBuilder.Create()
                    .Speech($"You have no work today.")
                    .MarkEndOfAssistantConversation()
                    .Build();
            }
            return FulfillmentResponseBuilder.Create()
                .Speech($"Your work is {hours} hours and {minutes} minutes long today.")
                .MarkEndOfAssistantConversation()
                .Build();    
        }
    }
}