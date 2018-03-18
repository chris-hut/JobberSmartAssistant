using System.Collections.Generic;
using Jobber.Sdk.Models.Clients;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class Job
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("start_at")]
        public long StartAt { get; set; }

        [JsonProperty("end_at")]
        public long EndAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("client")]
        public int Client { get; set; }

        [JsonProperty("quote")]
        public double? Quote { get; set; }

        [JsonProperty("notes")]
        public IEnumerable<Note> Notes { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<Properties> Properties { get; set; }

        [JsonProperty("line_items")]
        public IEnumerable<int> LineItems { get; set; }
    }
}
