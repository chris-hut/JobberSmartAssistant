using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlow.Sdk.Models
{
    public class IntentResponse
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public IEnumerable<ActionParameter> Parameters { get; set; }
        public IEnumerable<IntentContext> AffectedContexts { get; set; }
    }
}
