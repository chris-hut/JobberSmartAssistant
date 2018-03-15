using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Quote
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("sent_at")]
        public int SentAt { get; set; }

        [JsonProperty("job_description")]
        public string JobDescription { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("schedule_at")]
        public int ScheduleAt { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("client")]
        public Client MyClient { get; set; }

        [JsonProperty("changes_requested_at")]
        public int ChangedAt { get; set; }

        [JsonProperty("approved_at")]
        public int ApprovedAt { get; set; }

        [JsonProperty("property")]
        public Properties Property { get; set; }

    }
}
