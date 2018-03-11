using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents.Models
{
    public class IntentContext
    {
        public int Lifespan { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
    }
}