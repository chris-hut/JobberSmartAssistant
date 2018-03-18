using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;
using Refit;

namespace DialogFlow.Sdk
{
    public interface IDialogFlowClient
    {
        Task<IEnumerable<Intent>> GetIntentsAsync();
        Task CreateIntentAsync(Intent intent);
        Task UpdateIntentAsync(string intentId, Intent intent);
        Task DeleteIntentAsync(string intentId);
    }
}