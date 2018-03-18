using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Jobber.Sdk.Responses
{
    public class QuotesResponse
    {
        [JsonProperty("quotes")]
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        public int NumConvertable => Quotes.Count(quote => quote.Convertable());
    }
}