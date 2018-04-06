using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
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
            var quotes = await jobberClient.GetQuotesAsync();
            var numOfConvertableQuotes = quotes.NumConvertable;

            switch (numOfConvertableQuotes)
            {
                case 0:
                    return BuildNoConvertableQuotesFoundResponse();
                case 1:
                    return BuildSingleConvertableQuotesFoundResponse(quotes.ConvertableQuotes.First());
                default:
                    return BuildMultipleConvertableQuotesFoundResponse(numOfConvertableQuotes);
            }
        }

        private static FulfillmentResponse BuildMultipleConvertableQuotesFoundResponse(int numConvertableQuotes)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"There are {numConvertableQuotes} quotes ready to be converted into jobs.")
                .Build();
        }

        private static FulfillmentResponse BuildSingleConvertableQuotesFoundResponse(Quote quote)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have one quote that can be converted for {quote.Client.Name}.")
                .Build();
        }

        private static FulfillmentResponse BuildNoConvertableQuotesFoundResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Looks like there aren't any quotes that can be converted.")
                .Build();
        }
    }
}
