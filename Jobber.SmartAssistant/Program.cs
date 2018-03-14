using System;
using System.Threading;
using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.IntentFulfillers;
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

            var intentFulfiller = new JobberSmartAssistantIntentFulfiller()
                .WithJobberIntentFulfiller(new TennisIntentFulfiller());
            
            await Assistant.Sdk.Assistant.Builder()
                .UseWebHostBuilder(webHostBuilder)
                .UseIntentRegistry(new JobberIntentRegistry())
                .UseIntentSynchronizer(new DialogFlowIntentSynchronizer(null))
                .UseIntentFulfiller(intentFulfiller)
                .BuildAndRunAsync();
        }

        private static Configuration LoadConfiguration()
        {
            return new Configuration();
        }
    }
}