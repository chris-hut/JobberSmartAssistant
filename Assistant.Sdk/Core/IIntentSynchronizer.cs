using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;

namespace Assistant.Sdk.Core
{
    public interface IIntentSynchronizer
    {
        Task SynchronizeIntentsAsync(IEnumerable<Intent> intents);
    }
}