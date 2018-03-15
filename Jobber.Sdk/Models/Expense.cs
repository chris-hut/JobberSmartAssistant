using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Expense
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("entered_by_id")]
        public int EnteredById { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public string Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reimbursable")]
        public bool Reimbursable { get; set; }

        [JsonProperty("reimbursable_by_id")]
        public int ReimbursableId { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("processing")]
        public bool Processing { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("job")]
        public int Job { get; set; }
    }
}
