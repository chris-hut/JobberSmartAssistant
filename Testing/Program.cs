using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DialogFlow.Sdk;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Refit;

namespace Testing
{
    public class Program
    {

        public static async Task TestBuilding()
        {
            var config = new DialogFlowConfig
            {
                ApiKey = "7da136a3c39b48e1b955bd47f53e20a9"
            };

            var dialogFlowService = new DialogFlowServiceFactory(config).CreateDialogFlowService();

            var intent = IntentBuilder.For("tennis")
                .TriggerOn("I like tennis")
                .TriggerOn("I like tennis @sys.number:amount:10 out of 10")
                .RequireParameter(ParameterBuilder.Of("amount", "@sys.number")
                    .WithPrompt("How much do you like tennis out of 10?")
                    .WithPrompt("On a scale of 1 to 10, how much do you like tennis?")
                )
                .RespondsWith("Hey I like tennis $amount/10 too!")
                .Build();

            await dialogFlowService.CreateIntentAsync(intent);
        }

        public static async Task CreateActionAsync()
        {
            var config = new DialogFlowConfig
            {
                ApiKey = "7da136a3c39b48e1b955bd47f53e20a9"
            };

            var dialogFlowService = new DialogFlowServiceFactory(config).CreateDialogFlowService();

            var intent = new Intent
            {
                Name = "Testing",
                UserSays = new List<UserSays>
                {
                    new UserSays
                    {
                        Data = new List<IConversationData>
                        {
                            new TextData
                            {
                                Text = "I like hockey."
                            }
                        }
                    },
                    new UserSays
                    {
                        Data = new List<IConversationData>
                        {
                            new TextData
                            {
                                Text = "I like hockey "
                            },
                            new EntityData
                            {
                                Alias = "amount",
                                Meta = "@sys.number",
                                Text = "6",
                                UserDefined = true
                            },
                            new TextData
                            {
                                Text = " out of 10."
                            }
                        }
                    }
                },
                Responses = new List<IntentResponse>
                {
                    new IntentResponse
                    {
                        Name = "okay",
                        Action = "okay",
                        DefaultResponsePlatforms = new Dictionary<string, bool>
                        {
                            {"google", true}
                        },
                        Parameters = new List<Parameter>
                        {
                            new Parameter
                            {
                                DataType = "@sys.number",
                                Name = "amount",
                                Value = "$amount",
                                Prompts = new List<string> {"How much do you like hockey?"},
                                Required = true
                            }
                        },
                        Messages = new List<Message>
                        {
                            new SpeechMessage
                            {
                                Speech = "You like hockey $amount/10"
                            }
                        }
                    }
                }
            };

            var str = JsonConvert.SerializeObject(intent);
            var res = await dialogFlowService.CreateIntentAsync(intent);
        }

        public static void CreateServer()
        {

            WebHost.CreateDefaultBuilder()
                .UseUrls("http://0.0.0.0:5000")
                .Configure(builder => builder.Run(async c => await c.Response.WriteAsync("Testing")))
                .Build()
                .Run();


        }

        public static void Main(string[] args)
        {
            TestBuilding().Wait();
        }

    }

}