﻿using System.Collections.Generic;
using DialogFlow.Sdk.Models.Common;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Fulfillment
{
    public class FulfillmentResponse
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
        [JsonProperty("contextOut")]
        public List<Context> ContextOut { get; set; } = new List<Context>();
        [JsonProperty("data")]
        public IFulfillmentData Data { get; set; }
        
    }

    public interface IFulfillmentData
    {
        
    }
}