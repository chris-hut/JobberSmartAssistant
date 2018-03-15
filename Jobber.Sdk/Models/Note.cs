using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Note
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
