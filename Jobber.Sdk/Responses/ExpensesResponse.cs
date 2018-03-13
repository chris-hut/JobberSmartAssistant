using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class ExpensesResponse
    {
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
    }
}