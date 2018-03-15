using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Client
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("is_company")]
        public bool IsCompany { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public IEnumerable<Note> Notes { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<Properties> MyProperties { get; set; }
    }
}
