using System;
using System.Text;
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
            float currentEnd = 0;
            
            foreach (Visit visit in visits.Visits)
            {
                // To handle overlap intervals
                length += Math.Max(0, visit.EndAt - Math.Max(currentEnd, visit.StartAt));
                currentEnd = visit.EndAt;
            }
            float duration = (float) (length / 3600);
            int hours = (int) Math.Floor(duration);
            int minutes = (int) ((duration - hours) * 60);
            

            StringBuilder sb = new StringBuilder();
            if (hours == 0)
            {
                sb.Append($"You have no work today.");
            }
            else
            {
                if (hours >= 24)
                {
                    sb.Append($"You have work all day.");
                }
                else
                {
                    sb.Append($"Your work is {hours} hours and {minutes} minutes long today.");
                }
            }
            return FulfillmentResponseBuilder.Create()
                .Speech(sb.ToString())
                .Build();    
        }
    }
}