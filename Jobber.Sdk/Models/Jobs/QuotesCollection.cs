using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class QuotesCollection
    {
        [JsonProperty("quotes")]
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();

        public int NumConvertable => Quotes.Count(quote => quote.Convertable());
    }
}