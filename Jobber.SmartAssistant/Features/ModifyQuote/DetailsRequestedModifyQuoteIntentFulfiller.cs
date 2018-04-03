using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;
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
            var serviceName = fulfillmentRequest.GetParameter(Constants.Variables.ServiceName);

            var quotesCollection = await jobberClient.GetQuotesAsync();

            var filteredQuotes = quotesCollection.Quotes
                .Where(q => q.Client.Name.ContainsIgnoringCase(clientName))
                .Where(q => DoesLineItemsMatchUserQuery(q.LineItems, serviceName));

            switch (filteredQuotes.Count())
            {
                case 0:
                    return BuildResponseForNoMatchingQuotes();
                case 1:
                    return QuoteUtils.BuildResponseFor(filteredQuotes.First());
                default:
                    return BuildResponseForMuiltipleMatchesFor(fulfillmentRequest, filteredQuotes);
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
        
        private static FulfillmentResponse BuildResponseForMuiltipleMatchesFor(
            FulfillmentRequest fulfillmentRequest, IEnumerable<Quote> matchingQuotes)
        {
            return fulfillmentRequest.DoesRequestingDeviceHaveAScreen()
                ? BuildResponseForMultipleMatchesForDeviceWithScreen(matchingQuotes)
                : BuildResponseForMultipleMatchesForAudioDevice(matchingQuotes);
        }

        private static FulfillmentResponse BuildResponseForMultipleMatchesForDeviceWithScreen(
            IEnumerable<Quote> matchingQuotes)
        {
            var quoteSuggestions = matchingQuotes.Select(q => q.QuoteNumber.ToString()).ToList();
            quoteSuggestions.Add("Cancel");

            var suggestionChips = GoogleChipMessage.From(quoteSuggestions);

            return FulfillmentResponseBuilder.Create()
                .Speech("A few quotes matched what you said. Here are some of the quote numbers that matched:")
                .WithContext(ContextBuilder.For(Constants.Contexts.QuoteNumberRequested))
                .WithMessage(suggestionChips)
                .Build();
        }

        private static FulfillmentResponse BuildResponseForMultipleMatchesForAudioDevice(
            IEnumerable<Quote> matchingQuotes)
        {
            var commaSeperatedQuoteNumbers = matchingQuotes
                .Select(q => q.QuoteNumber.ToString())
                .ToCommaSeperatedSentence();

            var message = $"Quotes with numbers {commaSeperatedQuoteNumbers} all matched " +
                          $"what you said. If you remember the quote number you can pick " +
                          $"one to modify.";
            
            return FulfillmentResponseBuilder.Create()
                .Speech(message)
                .WithContext(ContextBuilder.For(Constants.Contexts.QuoteNumberRequested))
                .Build();
        }
    }
}