using System;
using System.Threading;
using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using Jobber.SmartAssistant.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Jobber.SmartAssistant
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = LoadConfiguration();
            
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseUrls($"http://0.0.0.0:{config.Port}");
            
            await Assistant.Sdk.Assistant.Builder()
                .UseWebHostBuilder(webHostBuilder)
                .UseIntentRegistry(new JobberIntentRegistry())
                .UseIntentSynchronizer(new DialogFlowIntentSynchronizer(null))
                .UseIntentFulfiller(new JobberSmartAssistantIntentFulfiller())
                .BuildAndRunAsync();
        }

        private static Configuration LoadConfiguration()
        {
            return new Configuration();
        }
    }
}