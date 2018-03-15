using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class User
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uuid")]
        public string  Uuid { get; set; }

        [JsonProperty("current_user")]
        public bool CurrentUser { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("permissions")]
        public IEnumerable<Permission> MyPermissions { get; set; }
    }
}
