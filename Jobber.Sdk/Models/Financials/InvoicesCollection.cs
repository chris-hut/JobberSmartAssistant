using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Financials
{
    public class InvoicesCollection
    {
        [JsonProperty("invoices")]
        public IEnumerable<Invoice> Invoices = new List<Invoice>();
    }
}