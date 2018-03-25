using System;

namespace Jobber.Sdk.Rest.Requests
{
    public class GetTransactionRequest
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string TimeUnit { get; set; }
    }
}
