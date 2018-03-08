using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class JobberModificationResponse
    {
        public string Id { get; set; }
        public JobberStatus Status { get; set; }
    }

    public class JobberStatus
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
