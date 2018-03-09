using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class Job
    {
        public int Id { get; set; }

        public bool Closed { get; set; }

        public int CreatedAt { get; set; }

        public int StartAt { get; set; }

        public int EndAt { get; set; }

        public string Status { get; set; }

        public int CLient { get; set; }

        public int Quote { get; set; }

    }
}
