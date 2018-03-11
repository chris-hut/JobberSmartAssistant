using System.Collections.Generic;
using DialogFlow.Sdk.Intents.Models;

namespace DialogFlow.Sdk.Fulfillment
{
    public class FullfillmentResponse
    {
        public string Speech { get; set; }
        public string DisplayText { get; set; }
        public List<IntentContext> ContextOut { get; set; } = new List<IntentContext>();
    }
}