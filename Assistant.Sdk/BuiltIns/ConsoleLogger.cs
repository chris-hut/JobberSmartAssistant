using System;
using Assistant.Sdk.Core;

namespace Assistant.Sdk.BuiltIns
{
    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string log)
        {
            Console.WriteLine($"info: {log}");
        }

        public void LogWarning(string log)
        {
            Console.WriteLine($"warn: {log}");
        }

        public void LogError(string log)
        {
            Console.WriteLine($"error: {log}");
        }
    }
}