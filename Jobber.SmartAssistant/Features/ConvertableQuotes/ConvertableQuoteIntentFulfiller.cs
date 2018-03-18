using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models;
using Jobber.Sdk.Responses;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.ConvertableQuotes
{
    class ConvertableQuoteIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.ConvertableQuotes);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberService jobberService)
        {
            var Quotes = await jobberService.GetQuotesAsync();
            var numOfConvertableQuotes = Quotes.NumConvertable;

            switch (numOfConvertableQuotes)
            {
                case 0:
                    return BuildNoConvertableQuotesFoundResponse();
                case 1:
                    return BuildSingleConvertableQuotesFoundResponse();
                default:
                    return BuildMultipleConvertableQuotesFoundResponse(numOfConvertableQuotes);
            }


        }

        private static FulfillmentResponse BuildMultipleConvertableQuotesFoundResponse(int numConvertableQuotes)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"There are {numConvertableQuotes} jobs ready to be converted into jobs")
                .Build();
        }

        private static FulfillmentResponse BuildSingleConvertableQuotesFoundResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("There is one quote ready to be converted into a job.")
                .Build();
        }

        private static FulfillmentResponse BuildNoConvertableQuotesFoundResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("There are no quotes ready to be converted into jobs.")
                .Build();
        }
    }
}
