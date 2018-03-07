using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlow.Sdk.Models
{
    public class Intent
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Auto { get; set; }
        public bool FallbackIntent { get; set; }
        public bool ResetsContext { get; set; }
        public bool WebhookUsed { get; set; }
        
        public int Priority { get; set; }
        
        public IEnumerable<string> Contexts { get; set; }
        public IEnumerable<string> Templates { get; set; }
        public IEnumerable<IntentResponse> Responses { get; set; }
    }
}
