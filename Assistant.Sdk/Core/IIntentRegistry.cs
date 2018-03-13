using System.Collections.Generic;
using DialogFlow.Sdk.Intents;

namespace Assistant.Sdk.Core
{
    public interface IIntentRegistry
    {
        IEnumerable<Intent> DefineIntents();
    }
}