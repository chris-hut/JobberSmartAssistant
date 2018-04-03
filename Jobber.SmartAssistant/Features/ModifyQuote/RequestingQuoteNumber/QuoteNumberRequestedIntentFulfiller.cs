using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.ModifyQuote.RequestingQuoteNumber
{
    public class QuoteNumberRequestedIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.QuoteNumberRequestedModifyQuote);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var quoteNumber = fulfillmentRequest.GetParameterAsInt(Constants.Variables.QuoteNumber);
            var quoteCollection = await jobberClient.GetQuotesAsync();
            var filteredQuotes = quoteCollection.Quotes.Where(q => q.QuoteNumber == quoteNumber);

            switch (filteredQuotes.Count())
            {
                case 1:
                    return QuoteUtils.BuildResponseFor(filteredQuotes.First());
                default:
                    return BuildResponseForNoMatchingQuotes(quoteNumber);
            }
        }

        private static FulfillmentResponse BuildResponseForNoMatchingQuotes(int quoteNumber)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"Sorry I could not find a quote with the matching number. I won't change any quotes. Goodbye.")
                .Build();
        }
    }
}