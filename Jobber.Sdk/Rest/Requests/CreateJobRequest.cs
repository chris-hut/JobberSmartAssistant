using System.Collections.Generic;
using Jobber.Sdk.Models.Jobs;
using Newtonsoft.Json;

namespace Jobber.Sdk.Rest.Requests
{
    public class CreateJobRequest
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("job_type")] 
        public string JobType { get; set; } = JobTypes.OneOff;

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
        public long? ClientId { get; set; }

        [JsonProperty("property")] 
        public long? PropertyId { get; set; }

        [JsonProperty("quote")]
        public long? QuoteId { get; set; }

        [JsonProperty("notes")]
        public IEnumerable<Note> Notes { get; set; }

        [JsonProperty("line_items")]
        public IEnumerable<int> LineItems { get; set; }
    }
}