using System;

namespace DialogFlow.Sdk.Rest
{
    public class DialogFlowException : Exception
    {
        public DialogFlowException(string errorDescription, DialogFlowStatusResponse dialogFlowStatusResponse)
            : base(BuildErrorMessageFor(errorDescription, dialogFlowStatusResponse)) { }

        private static string BuildErrorMessageFor(string errorDescription, DialogFlowStatusResponse dialogFlowStatusResponse)
        {
            return $"{errorDescription} because of {dialogFlowStatusResponse.ErrorMessage}";
        }
    }
}