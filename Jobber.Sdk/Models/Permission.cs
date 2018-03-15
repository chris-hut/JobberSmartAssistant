using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Permission
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        [JsonProperty("create")]
        public bool Create { get; set; }

        [JsonProperty("write")]
        public bool Write { get; set; }

        [JsonProperty("Manage")]
        public bool Manage { get; set; }

        [JsonProperty("delete")]
        public bool Delete { get; set; }

        [JsonProperty("list")]
        public bool List { get; set; }
    }
}
