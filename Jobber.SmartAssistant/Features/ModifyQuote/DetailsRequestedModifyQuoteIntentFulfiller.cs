using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
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
            var serviceName = fulfillmentRequest.GetParameter(Constants.Variables.ServiceNames);

            var quotesCollection = await jobberClient.GetQuotesAsync();

            var filteredQuotes = quotesCollection.Quotes
                .Where(q => q.Client.Name.ContainsIgnoringCase(clientName))
                .Where(q => DoesLineItemsMatchUserQuery(q.LineItems, serviceName));

            switch (filteredQuotes.Count())
            {
                case 0:
                    return BuildResponseForNoMatchingQuotes();
                case 1:
                    return BuildResponseFor(filteredQuotes.First());
                default:
                    return BuildResponseForMuiltipleMatches();
            }
        }

        private static bool DoesLineItemsMatchUserQuery(IEnumerable<LineItem> lineItems, string serviceName)
        {
            return lineItems.Any(l => l.Name.ContainsIgnoringCase(serviceName));
        }

        private static FulfillmentResponse BuildResponseForNoMatchingQuotes()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("Sorry, I couldn't find a quote that matches what you said")
                .Build();
        }

        private static FulfillmentResponse BuildResponseFor(Quote quote)
        {
            var outgoingContext = new ModifyQuoteContext { Quote = quote };
            
            var serviceDescriptions = quote.LineItems
                .Select(l => $"{l.Name} with a unit cost of ${l.UnitCost}");

            var joinedServicesDescriptions = String.Join(", ", serviceDescriptions);

            var responseSpeech = $"Okay the quote currently has {quote.LineItems.Count()} " +
                                  $"services. {joinedServicesDescriptions}. Please let me know what service " +
                                  $"you would like to update.";

            return FulfillmentResponseBuilder.Create()
                .Speech(responseSpeech)
                .WithContext(ContextBuilder.For(Constants.Contexts.QuoteDetailsSet)
                    .WithParameter(Constants.Variables.ModifyQuoteContext, outgoingContext)
                )
                .Build();
        }
        
        private static FulfillmentResponse BuildResponseForMuiltipleMatches()
        {
            var message = "Sorry, it looks like there are multiple quotes " +
                          "that match what you said. I'm not sure which one to modify.";
            
            return FulfillmentResponseBuilder.Create()
                .Speech(message)
                .Build();
        }
    }
}