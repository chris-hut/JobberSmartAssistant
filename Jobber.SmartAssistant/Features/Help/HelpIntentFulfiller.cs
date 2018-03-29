using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;
using Jobber.Sdk;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Clients;
using Jobber.SmartAssistant.Core;
using Remotion.Linq.Clauses.ResultOperators;
using Jobber.SmartAssistant.Extensions;

namespace Jobber.SmartAssistant.Features.Help
{
    public class HelpIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.Help);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var userId = fulfillmentRequest.GetCurrentUserId();
            var userCollection = await jobberClient.GetUserAsync(userId);
            var user = userCollection.Users;
            var chipSuggestionMessage = GoogleChipMessage.From(user.PossibleActions().Values.ToList());

            return FulfillmentResponseBuilder.Create()
                .Speech("I have listed some functionalities as suggestions")
                .WithMessage(chipSuggestionMessage)
                .Build();
        }
    }
}
