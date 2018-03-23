﻿using System;
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

            var Transactions = await jobberClient.GetRangedTransactionsAsync();
            double revenue = Transactions.GetTotal();

            return FulfillmentResponseBuilder.Create()
                .Speech($"We made ${revenue}")
                .Build();
        }
    }
}
