using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Models.Intents;

namespace Assistant.Sdk.Core
{
    public interface IIntentSynchronizer
    {
        Task SynchronizeIntentsAsync(IEnumerable<Intent> intents);
    }
}