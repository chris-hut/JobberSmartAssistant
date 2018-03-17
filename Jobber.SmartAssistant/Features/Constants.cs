namespace Jobber.SmartAssistant.Features
{
    public static class Constants
    {
        public const string AssistantName = "Jobber Bot";



        public static class Intents
        {
            public const string StartCreateJob = "START_CREATE_JOB";
            public const string ClientSetCreateJob = "CLIENT_SET_CREATE_JOB";
            public const string UnassignedVisits = "Unassigned_Visits";
        }

        public static class Variables
        {
            public const string ClientName = "CLIENT_NAME";
            public const string ClientId = "CLIENT_ID";
            public const string Description = "DESCRIPTION";
            public const string Date = "DATE"; 
        }

    }
}