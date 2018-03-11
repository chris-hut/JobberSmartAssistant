using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
{
    public class IntentResponse
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public Dictionary<string, bool> DefaultResponsePlatforms { get; set; } = new Dictionary<string, bool>();
        public IEnumerable<ActionParameter> Parameters { get; set; } = new List<ActionParameter>();
        public IEnumerable<IntentMessage> Messages { get; set; } = new List<IntentMessage>();
        public IEnumerable<IntentContext> AffectedContexts { get; set; } = new List<IntentContext>();
    }
}
