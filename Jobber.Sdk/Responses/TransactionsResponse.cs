using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class TransactionsResponse
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}