using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public class GoogleChipMessage : GoogleMessage
    {
        [JsonProperty("suggestions")]
        public IList<SuggestionChip> Suggestions { get; set; } = new List<SuggestionChip>();
        
        public GoogleChipMessage() : base("suggestion_chips") { }

        public static GoogleChipMessage From(IEnumerable<string> suggestions)
        {
            return new GoogleChipMessage
            {
                Suggestions = suggestions
                    .Select(s => new SuggestionChip { Title = s })
                    .ToList()
            };
        }
    }

    public class SuggestionChip
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}