using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class QuotesResponse
    {
        [JsonProperty("quotes")]
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();
    }
}