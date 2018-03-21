using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.ConvertableQuotes
{
    public class ConvertibleQuoteIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.ConvertibleQuotes);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var Quotes = await jobberClient.GetQuotesAsync();
            var numOfConvertableQuotes = Quotes.NumConvertable;

            //switch (numOfConvertableQuotes)
            //{
            //    case 0:
            //        return BuildNoConvertableQuotesFoundResponse();
            //    case 1:
            //        return BuildSingleConvertableQuotesFoundResponse();
            //    default:
            //        return BuildMultipleConvertableQuotesFoundResponse(numOfConvertableQuotes);
            //}
            return FulfillmentResponseBuilder.Create()
                .Speech($"There are {numOfConvertableQuotes} jobs ready to be converted into jobs")
                .Build();


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
