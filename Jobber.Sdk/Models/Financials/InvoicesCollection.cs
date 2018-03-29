using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Jobber.Sdk.Models.Financials
{
    public class InvoicesCollection
    {
        [JsonProperty("invoices")]
        public IEnumerable<Invoice> Invoices = new List<Invoice>();

        public int Count() => Invoices.Count();

        public int NumSendable() => Invoices.Count(invoice => invoice.NotYetSent());
    }
}