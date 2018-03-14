using System.Collections.Generic;
using System.Linq;
using Assistant.Sdk.Core;
using DialogFlow.Sdk.Intents;

namespace Assistant.Sdk.BuiltIns
{
    public class DefaultIntentRegistry : IIntentRegistry
    {
        private readonly IList<IIntentDefinition> _intentDefinitions;

        public DefaultIntentRegistry()
        {
            _intentDefinitions = new List<IIntentDefinition>();    
        }

        public DefaultIntentRegistry WithIntentDefinition(IIntentDefinition intentDefinition)
        {
            _intentDefinitions.Add(intentDefinition);
            return this;
        }
        
        public IEnumerable<Intent> DefineIntents()
        {
            return _intentDefinitions.Select(d => d.DefineIntent());
        }
    }
}