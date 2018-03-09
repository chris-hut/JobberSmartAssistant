using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class Expense
    {

        public int Id { get; set; }

        public int EnteredById { get; set; }

        public string Name { get; set; }

        public string Cost { get; set; }

        public string Desccription { get; set; }

        public bool Reimbursable { get; set; }

        public int ReimbursableId { get; set; }

        public int Date { get; set; }

        public bool Processing { get; set; }

        public string FileName { get; set; }

        public int CreatedAt { get; set; }

        public int UpdatedAt { get; set; }

        public int Job { get; set; }
    }
}
