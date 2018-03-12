using System.Collections.Generic;

namespace Jobber.Sdk.Models
{
    public class InvoicesResponse
    {
        public IEnumerable<Invoice> Invoices = new List<Invoice>();
    }
}