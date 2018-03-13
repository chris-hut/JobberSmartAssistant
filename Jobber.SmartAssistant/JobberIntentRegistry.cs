using System.Collections.Generic;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Intents;

namespace Jobber.SmartAssistant
{
    public class JobberIntentRegistry : IIntentRegistry
    {
        public IEnumerable<Intent> DefineIntents()
        {
            return new List<Intent>();
        }
    }
}