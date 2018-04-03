using System;
using System.Linq;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk.Models.Jobs;

namespace Jobber.SmartAssistant.Features.ModifyQuote
{
    public static class QuoteUtils
    {
        public static FulfillmentResponse BuildResponseFor(Quote quote)
        {
            var outgoingContext = new ModifyQuoteContext { Quote = quote };
            
            var serviceDescriptions = quote.LineItems
                .Select(l => $"{l.Name} with a cost of ${l.Cost}");

            var joinedServicesDescriptions = String.Join(", ", serviceDescriptions);

            var serviceWord = quote.LineItems.Count() == 1 ? "service" : "services";
            
            var responseSpeech = $"Okay the quote currently has {quote.LineItems.Count()} " +
                                 $"{serviceWord}. {joinedServicesDescriptions}. Please let me know what service " +
                                 $"you would like to update.";

            return FulfillmentResponseBuilder.Create()
                .Speech(responseSpeech)
                .WithContext(ContextBuilder.For(Constants.Contexts.QuoteDetailsSet)
                    .WithParameter(Constants.Variables.ModifyQuoteContext, outgoingContext)
                )
                .Build();
        }
    }
}