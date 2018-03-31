using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Financials;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.ModifyQuote
{
    public class DetailsRequestedModifyQuoteIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.DetailsRequestedModifyQuote);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var clientName = fulfillmentRequest.GetParameter(Constants.Variables.ClientName);
            var serviceNames = fulfillmentRequest.GetParamterAs<List<string>>(Constants.Variables.ServiceNames);

            var quotesCollection = await jobberClient.GetQuotesAsync();

            var filteredQuotes = quotesCollection.Quotes
                .Where(q => q.Client.Name.ContainsIgnoringCase(clientName))
                .Where(q => DoesLineItemsMatchUserQuery(q.LineItems, serviceNames));

            switch (filteredQuotes.Count())
            {
                case 0:
                    return BuildResponseForNoMatchingQuotes();
                default:
                    return BuildResponseForMuiltipleMatches();
            }
        }

        private static bool DoesLineItemsMatchUserQuery(IEnumerable<LineItem> lineItems, 
            IEnumerable<string> userDefinedServices)
        {
            return userDefinedServices
                .All(s => lineItems.Any(l => l.Name.ContainsIgnoringCase(s)));
        }

        private static FulfillmentResponse BuildResponseForNoMatchingQuotes()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Sorry, I couldn't find a quote that matches what you said")
                .Build();
        }

        public static FulfillmentResponse BuildResponseForMuiltipleMatches()
        {
            var message = "Sorry, it looks like there are multiple quotes " +
                          "that match what you said. I'm not sure which one to modify.";
            
            return FulfillmentResponseBuilder.Create()
                .Speech(message)
                .Build();
        }
    }
}