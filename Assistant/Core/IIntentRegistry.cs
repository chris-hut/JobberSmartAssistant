using System.Collections.Generic;
using DialogFlow.Sdk.Intents;

namespace Assistant.Core
{
    public interface IIntentRegistry
    {
        IEnumerable<Intent> RegisterIntents();
    }
}