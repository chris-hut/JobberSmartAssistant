using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlow.Sdk.Models
{
    public class Intent
    {
        public bool Auto { get; set; }
        public IEnumerable<string> Contexts { get; set; }
        public string Name { get; set; }
    }
}
