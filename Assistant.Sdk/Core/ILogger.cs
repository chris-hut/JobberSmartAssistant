namespace Assistant.Sdk.Core
{
    public interface ILogger
    {
        void LogInfo(string log);
        void LogWarning(string log);
        void LogError(string log);
    }
}