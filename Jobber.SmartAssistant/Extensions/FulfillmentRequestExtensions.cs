using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using DialogFlow.Sdk.Models.Fulfillment;

namespace Jobber.SmartAssistant.Extensions
{
    public static class FulfillmentRequestExtensions
    {
        public static long GetCurrentUserId(this FulfillmentRequest fulfillmentRequest)
        {
            if (fulfillmentRequest.UserId != -1)
            {
                return fulfillmentRequest.UserId;
            }
            var token = fulfillmentRequest.OriginalRequest.Data.User.AccessToken;
            var decoded = new JwtSecurityToken(jwtEncodedString: token);
            return Convert.ToInt64(decoded.Claims.First(c => c.Type == "user_id").Value);
        }
    }
}