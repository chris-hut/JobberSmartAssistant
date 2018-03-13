using System;
using System.Threading;
using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Jobber.SmartAssistant
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseUrls("http://0.0.0.0:5000");
            
            await Assistant.Sdk.Assistant.Builder()
                .UseWebHostBuilder(webHostBuilder)
                .UseIntentRegistry(new JobberIntentRegistry())
                .UseIntentSynchronizer(new DialogFlowIntentSynchronizer(null))
                .UseIntentFulfiller(new JobberIntentFulfiller())
                .BuildAndRunAsync();
        }
    }
}