using System.Collections.Generic;
using DialogFlow.Sdk.Models.Intents;

namespace Assistant.Sdk.Core
{
    public interface IIntentRegistry
    {
        IEnumerable<Intent> DefineIntents();
    }
}