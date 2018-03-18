using System;

namespace DialogFlow.Sdk.Rest
{
    public class DialogFlowException : Exception
    {
        public DialogFlowException(string errorDescription, IntentStatusResponse intentStatusResponse)
            : base(BuildErrorMessageFor(errorDescription, intentStatusResponse)) { }

        private static string BuildErrorMessageFor(string errorDescription, IntentStatusResponse intentStatusResponse)
        {
            return $"{errorDescription} because of {intentStatusResponse.ErrorMessage}";
        }
    }
}