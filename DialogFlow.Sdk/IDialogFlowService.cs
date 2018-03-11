using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;
using Refit;

namespace DialogFlow.Sdk
{
    public interface IDialogFlowService
    {
        [Post("/intents")]
        Task<IntentModificationResponse> CreateIntent([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<IntentModificationResponse> UpdateIntent([AliasAs("intentId")] string intentId, [Body] Intent intent);
    }
}
