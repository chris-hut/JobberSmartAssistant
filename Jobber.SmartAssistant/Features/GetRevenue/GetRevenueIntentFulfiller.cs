using System;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.GetRevenue
{
    public class GetRevenueIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetRevenue);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {

            var lastSunday = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
            var lastMonday = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek-6);

            var lastSundayEpoch = DateTimeExtensions.ToUnixTime(lastSunday);
            var lastMondayEpoch = DateTimeExtensions.ToUnixTime(lastMonday);

            var Transactions = await jobberClient.GetRangedTransactionsAsync(lastMondayEpoch, lastSundayEpoch);

            var revenue = 1;

            return FulfillmentResponseBuilder.Create()
                .Speech($"We made {revenue} dollar")
                .Build();
        }
    }
}
