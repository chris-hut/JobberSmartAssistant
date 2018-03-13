using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;

namespace Assistant.Core
{
    public interface IIntentSynchronizer
    {
        Task SyncronizeIntentsAsync(IEnumerable<Intent> intents);
    }
}