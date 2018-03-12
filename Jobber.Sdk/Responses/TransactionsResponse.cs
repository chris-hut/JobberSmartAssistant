using System.Collections.Generic;

namespace Jobber.Sdk.Models
{
    public class TransactionsResponse
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}