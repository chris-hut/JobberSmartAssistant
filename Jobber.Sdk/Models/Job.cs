using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class Job
    {
        public bool Auto { get; set; }
        public IEnumerable<string> Contexts { get; set; }
        public string Name { get; set; }
    }
}
