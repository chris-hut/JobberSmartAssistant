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

            public const string UnassignedVisits = "UNASSIGNED_VISITS";
            public const string ConvertibleQuotes = "CONVERTIBLE_QUOTES"; 
        }

        public static class Variables
        {
            public const string ClientName = "CLIENT_NAME";
            public const string ClientId = "CLIENT_ID";
            public const string PropertyId = "PROPERTY_ID";
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