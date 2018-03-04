using System;
using System.Collections.Generic;
using System.Text;

namespace DialogFlow.Sdk.Models
{
    public class IntentModificationResponse
    {
        public string Id { get; set; }
        public IntentStatus Status { get; set; }
    }

    public class IntentStatus
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
