using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.GetAssignedVisits
{
    public class GetAssignedVisitsIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetAssignedVisits);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            // Get user_id
            var token = fulfillmentRequest.OriginalRequest.Data.User.AccessToken;
            var decoded = new JwtSecurityToken(jwtEncodedString: token);
            var user_id = (long) Convert.ToDouble(decoded.Claims.First(c => c.Type == "user_id").Value);
            var visits = await jobberClient.GetTodayAssignedVisitsAsync(user_id);
            
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
                .Speech($"You have one job today. {visit.Title}")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse buildMultipleVisitsFoundResponse(VisitsCollections visits)
        {
            // This is temporary, need to specify date range
            var first2_visits = visits.Visits.Take(2);
            StringBuilder sb = new StringBuilder();
            foreach (Visit visit in first2_visits)
            {
                sb.Append(visit.Title + ". ");
            }
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {visits.Count} jobs today. Visits include: {sb.ToString()}")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}