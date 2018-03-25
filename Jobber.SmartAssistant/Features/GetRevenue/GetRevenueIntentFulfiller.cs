using System;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using System.Linq;

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
            string lastTextInput = fulfillmentRequest.OriginalRequest.Data.Inputs.FirstOrDefault().RawInputs.FirstOrDefault().Query.Split(" ").Last();
            var Transactions = await jobberClient.GetRangedTransactionsAsync(lastTextInput);
            double revenue = Transactions.GetTotal();

            if (lastTextInput.ToLower() != "month" && lastTextInput.ToLower() != "year")
            {
                lastTextInput = "week";
            }

            return FulfillmentResponseBuilder.Create()
                .Speech($"We made ${revenue} last {lastTextInput}")
                .Build();
        }
    }
}
