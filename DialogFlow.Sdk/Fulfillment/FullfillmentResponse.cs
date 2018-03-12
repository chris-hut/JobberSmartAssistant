using System.Collections.Generic;
using DialogFlow.Sdk.Intents;

namespace DialogFlow.Sdk.Fulfillment
{
    public class FullfillmentResponse
    {
        public string Speech { get; set; }
        public string DisplayText { get; set; }
        public List<Context> ContextOut { get; set; } = new List<Context>();
    }
}