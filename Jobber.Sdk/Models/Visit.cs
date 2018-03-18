using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Visit
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("scheduled")]
        public bool Scheduled { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("completable")]
        public bool Completable { get; set; }

        [JsonProperty("start_at")]
        public int StartAt { get; set; }

        [JsonProperty("end_at")]
        public int EndAt { get; set; }

        [JsonProperty("pretty_range")]
        public string PrettyRange { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("client")]
        public Client MyClient { get; set; }

        [JsonProperty("job")]
        public Job MyJob { get; set; }

        [JsonProperty("property")]
        public Properties MyProperty { get; set; }

        [JsonProperty("assigned_to")]
        public  IEnumerable<Assigned> AssignedTo { get; set; }

        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }

        public bool IsAssigned()
        {
            return AssignedTo.Any();
        }

        public bool NotAssigned()
        {
            return !AssignedTo.Any();
        }


    }
}
