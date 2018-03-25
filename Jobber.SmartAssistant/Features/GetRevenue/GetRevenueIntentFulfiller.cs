using System;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using System.Linq;
using DialogFlow.Sdk.Models.Common;
using Jobber.Sdk.Rest.Requests;

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
            var datePeriod = GetDatePeriodForRevenueFrom(fulfillmentRequest);
            var timeUnit = fulfillmentRequest.GetParameter(Constants.Variables.TimeUnitOriginal);

            if (timeUnit == null)
            {
                timeUnit = "week";
            }

            var getTransactionRequest = new GetTransactionRequest
            {
                Start = datePeriod.Start,
                End = datePeriod.End,
                TimeUnit = timeUnit
            };

            var Transactions = await jobberClient.GetRangedTransactionsAsync(getTransactionRequest);
            double revenue = Transactions.GetTotal();



            return FulfillmentResponseBuilder.Create()
                .Speech($"We made ${revenue} last {timeUnit}")
                .Build();
        }

        private static DatePeriod GetDatePeriodForRevenueFrom(FulfillmentRequest fulfillmentRequest)
        {
            if (fulfillmentRequest.IsParameterDatePeriod(Constants.Variables.TimeUnit))
            {
                return fulfillmentRequest.GetParemterAsDatePeriod(Constants.Variables.TimeUnit);
            }

            return new DatePeriod
            {
                End = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                Start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 6)
            };
        }
    }
}
