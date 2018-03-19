using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.SmartAssistant.Core;

namespace Jobber.SmartAssistant.Features.SendableInvoices
{
    public class SendableInvoivesIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.SendableInvoices);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var Invoices = await jobberClient.GetInvoicesAsync();
            var numOfSendableInvoices = Invoices.NumSendable();

            switch (numOfSendableInvoices)
            {
                case 0:
                    return BuildNoSendableInvoicesFoundResponse();
                case 1:
                    return BuildSingleSendableInvoiceFoundResponse();
                default:
                    return BuildMultipleSendableInvoicesFoundResponse(numOfSendableInvoices);
            }
        }

        private static FulfillmentResponse BuildMultipleSendableInvoicesFoundResponse(int numOfSendableInvoices)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"There are {numOfSendableInvoices} invoices ready to be sent")
                .Build();
        }

        private static FulfillmentResponse BuildSingleSendableInvoiceFoundResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("There is one invoice ready to be sent.")
                .Build();
        }

        private static FulfillmentResponse BuildNoSendableInvoicesFoundResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech("There are no invoices ready to be sent.")
                .Build();
        }
    }
}
