using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DialogFlow.Sdk.Models.Messages
{
    public class GoogleCardMessage : Message<string>
    {
        [JsonProperty("platform")] 
        public string Platform { get; } = "google";
        
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }
        [JsonProperty("formattedText")]
        public string FormattedText { get; set; }
        [JsonProperty("image")]
        public UrlContainer Image { get; set; }

        public GoogleCardMessage() : base("basic_card") { }
    }

    public class UrlContainer
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CardButton
    {
        [JsonProperty("openUrlAction")]
        public UrlContainer Url { get; set; }
        [JsonProperty("title")]
        public string Label { get; set; }
    }
}