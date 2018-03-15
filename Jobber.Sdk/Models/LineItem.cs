﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class LineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }
    }
}