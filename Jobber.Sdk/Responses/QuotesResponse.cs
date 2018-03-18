using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;
using System.Linq;
using Jobber.Sdk.Models.Jobs;

namespace Jobber.Sdk.Responses
{
    public class QuotesResponse
    {
        [JsonProperty("quotes")]
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        public int NumConvertable => Quotes.Count(quote => quote.Convertable());
    }
}