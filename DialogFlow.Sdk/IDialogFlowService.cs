using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;
using Refit;

namespace DialogFlow.Sdk
{
    public interface IDialogFlowService
    {
        [Get("/intents")]
        Task<IEnumerable<Intent>> GetIntentsAsync();
        
        [Post("/intents")]
        Task<IntentModificationResponse> CreateIntentAsync([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<IntentModificationResponse> UpdateIntentAsync([AliasAs("intentId")] string intentId, [Body] Intent intent);

        [Delete("/intents/{intentId}")]
        Task<IntentModificationResponse> DeleteIntentAsync([AliasAs("intentId")] string intentId);
    }
}
