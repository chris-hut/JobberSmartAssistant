using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;
using Refit;

namespace DialogFlow.Sdk
{
    public interface IDialogFlowApi
    {
        [Get("/intents")]
        Task<IEnumerable<Intent>> GetIntentsAsync();
        
        [Post("/intents")]
        Task<IntentStatusResponse> CreateIntentAsync([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<IntentStatusResponse> UpdateIntentAsync([AliasAs("intentId")] string intentId, [Body] Intent intent);

        [Delete("/intents/{intentId}")]
        Task<IntentStatusResponse> DeleteIntentAsync([AliasAs("intentId")] string intentId);
    }
}
