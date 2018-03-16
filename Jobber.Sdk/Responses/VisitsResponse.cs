using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class VisitsResponse
    {
        [JsonProperty("visits")]
        public IEnumerable<Visit> Visits { get; set; } = new List<Visit>();
    }
}