using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
{
    public class ActionParameter
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public string Value { get; set; }
        
        public bool IsList { get; set; }
        public bool Required { get; set; }
        
        public IEnumerable<string> Prompts { get; set; }
    }
}