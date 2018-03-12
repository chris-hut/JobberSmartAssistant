using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
{
    public class IntentResponse
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public Dictionary<string, bool> DefaultResponsePlatforms { get; set; } = new Dictionary<string, bool>();
        public IEnumerable<Parameter> Parameters { get; set; } = new List<Parameter>();
        public IEnumerable<Message> Messages { get; set; } = new List<Message>();
        public IEnumerable<Context> AffectedContexts { get; set; } = new List<Context>();
    }
}
