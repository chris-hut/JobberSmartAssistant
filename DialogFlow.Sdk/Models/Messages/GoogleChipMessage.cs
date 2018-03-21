using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public class GoogleChipMessage : GoogleMessage
    {
        [JsonProperty("suggestions")]
        public IList<SuggestionChip> Suggestions { get; set; } = new List<SuggestionChip>();
        
        public GoogleChipMessage() : base("suggestion_chips") { }
    }

    public class SuggestionChip
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}