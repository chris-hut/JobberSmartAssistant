using System;
using System.Threading;
using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Features.Tennis;
using Jobber.SmartAssistant.Features.Welcome;
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

            var intentRegistry = new DefaultIntentRegistry()
                .WithIntentDefinition(new WelcomeIntentDefinition())
                .WithIntentDefinition(new TennisIntentDefinition());
            
            var intentFulfiller = new JobberSmartAssistantIntentFulfiller()
                .WithJobberIntentFulfiller(new TennisIntentFulfiller());

            var dialogFlowConfig = new DialogFlowConfig
            {
                ApiKey = config.DialogFlowApiKey
            };

            var dialogFlowService = new DialogFlowServiceFactory(dialogFlowConfig).CreateDialogFlowService();
            
            await Assistant.Sdk.Assistant.Builder()
                .UseWebHostBuilder(webHostBuilder)
                .UseIntentRegistry(intentRegistry)
                .UseIntentSynchronizer(new DialogFlowIntentSynchronizer(dialogFlowService))
                .UseIntentFulfiller(intentFulfiller)
                .BuildAndRunAsync();
        }

        private static Configuration LoadConfiguration()
        {
            return new Configuration
            {
                DialogFlowApiKey = Environment.GetEnvironmentVariable("JSA_DIALOG_FLOW_KEY"),
                Port = GetPortFromEnvironment()
            };
        }

        private static int GetPortFromEnvironment()
        {
            var portValue = Environment.GetEnvironmentVariable("PORT");
            if (String.IsNullOrEmpty(portValue))
            {
                return 5000;
            }

            return int.Parse(portValue);
        }
    }
}