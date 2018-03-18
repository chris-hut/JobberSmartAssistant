using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Models.Intents;
using Refit;

namespace DialogFlow.Sdk.Rest
{
    public interface IDialogFlowApi
    {
        [Get("/intents")]
        Task<IEnumerable<Intent>> GetIntentsAsync();
        
        [Post("/intents")]
        Task<DialogFlowStatusResponse> CreateIntentAsync([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<DialogFlowStatusResponse> UpdateIntentAsync([AliasAs("intentId")] string intentId, [Body] Intent intent);

        [Delete("/intents/{intentId}")]
        Task<DialogFlowStatusResponse> DeleteIntentAsync([AliasAs("intentId")] string intentId);
    }
}
