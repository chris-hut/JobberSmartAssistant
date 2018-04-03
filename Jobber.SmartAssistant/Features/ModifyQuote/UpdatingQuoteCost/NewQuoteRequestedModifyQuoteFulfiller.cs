using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.ModifyQuote.UpdatingQuoteCost
{
    public class NewQuoteRequestedModifyQuoteFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.NewQuoteRequestedModifyQuote);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var serviceName = fulfillmentRequest.GetParameter(Constants.Variables.ServiceName);
            var newUnitPrice = fulfillmentRequest.GetParameterAsDouble(Constants.Variables.Price);
            var modifyQuoteContext = fulfillmentRequest.GetContextParameterAs<ModifyQuoteContext>(
                Constants.Contexts.QuoteDetailsSet, Constants.Variables.ModifyQuoteContext);

            var modifiedQuote = UpdateServicePriceInQuote(modifyQuoteContext.Quote, serviceName, newUnitPrice);

            await jobberClient.UpdateQuoteAsync(modifiedQuote);

            return FulfillmentResponseBuilder.Create()
                .Speech("Okay. I've updated the quote for you.")
                .Build();
        }

        private static Quote UpdateServicePriceInQuote(Quote quote, string serviceName, double newPrice)
        {
            var modifiedServices = quote
                .LineItems
                .SelectWhere(l => l.Name.ContainsIgnoringCase(serviceName), l => l.WithCost(newPrice));

            quote.LineItems = modifiedServices.ToList();

            return quote;
        }
    }
}