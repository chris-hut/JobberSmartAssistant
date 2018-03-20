using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DialogFlow.Sdk.Models.Messages
{
    public class GoogleCardMessage : GoogleMessage
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
        public Image Image { get; set; } = new Image();
        [JsonProperty("buttons")]
        public IList<GoogleCardButton> Buttons { get; set; } = new List<GoogleCardButton>();

        public GoogleCardMessage() : base("basic_card") { }
    }

    public class Image : UrlContainer
    {
        [JsonProperty("accessibilityText")]
        public string AccessibilityText { get; set; }
    }

    public class UrlContainer
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class GoogleCardButton
    {
        [JsonProperty("openUrlAction")] 
        public UrlContainer Url { get; set; } = new UrlContainer();
        [JsonProperty("title")]
        public string Label { get; set; }
    }
}