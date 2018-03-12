using System.Collections.Generic;

namespace Jobber.Sdk.Models
{
    public class ExpensesResponse
    {
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
    }
}