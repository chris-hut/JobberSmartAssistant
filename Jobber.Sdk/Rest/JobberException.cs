using System;

namespace Jobber.Sdk.Rest
{
    public class JobberException : Exception
    {
        public JobberException(string errorMessage, string errorCause) :
            base(BuildExceptionMessageFrom(errorMessage, errorCause)) { }

        private static string BuildExceptionMessageFrom(string errorMessage, string errorCause)
        {
            return $"{errorMessage} because of:\n{errorCause}";
        }
    }
}