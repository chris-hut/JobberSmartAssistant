using System.Threading.Tasks;
using DialogFlow.Sdk.Intents.Models;
using Refit;

namespace DialogFlow.Sdk.Intents
{
    public interface IIntentService
    {
        [Post("/intents")]
        Task<IntentModificationResponse> CreateIntent([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<IntentModificationResponse> UpdateIntent([AliasAs("intentId")] string intentId, [Body] Intent intent);
    }
}
