using Newtonsoft.Json;

namespace Jobber.SmartAssistant.Features
{
    public static class Constants
    {
        public const string AssistantName = "Jobber Bot";



        public static class Intents
        {
            public const string Welcome = "WELCOME_INTENT";
            public const string Fallback = "FALLBACK_INTENT";
            public const string StartCreateJob = "START_CREATE_JOB";
            public const string ClientRequestedCreateJob = "CLIENT_REQUESTED_CREATE_JOB"; 
            public const string DescritptionRequestedCreateJob = "DESCRIPTION_REQUESTED_CREATE_JOB";

            public const string GetCompletableVisits = "GET_COMPLETEABLE_VISITS";
            public const string UnassignedVisits = "UNASSIGNED_VISITS";
            public const string ConvertibleQuotes = "CONVERTIBLE_QUOTES";
            public const string SendableInvoices = "SENDABLE_INVOICES";
            public const string GetRevenue = "GET_REVENUE";
            public const string GetJobs = "GET_JOBS";
            public const string GetAmountOfJobs = "GET_AMOUNT_OF_JOBS";
            public const string GetLengthWorkDay = "GET_LENGTH_WORK_DAY";
        }

        public static class Variables
        {
            public const string ClientName = "CLIENT_NAME";
            public const string CreateJobContext = "CREATE_JOB_CONTEXT";
            public const string JobDescription = "DESCRIPTION";
            public const string JobDate = "DATE";
        }

        public static class Contexts
        {
            public const string CreateJobClientRequested = "CREATE_JOB_CLIENT_REQUESTED";
            public const string CreateJobClientSet = "CREATE_JOB_CLIENT_SET";
        }

    }
}