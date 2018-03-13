using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class InvoicesResponse
    {
        public IEnumerable<Invoice> Invoices = new List<Invoice>();
    }
}