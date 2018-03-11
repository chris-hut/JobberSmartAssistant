using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DialogFlow.Sdk;
using DialogFlow.Sdk.Intents.Models;
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

        public async Task CreateActionAsync()
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
                         Data = new List<IUserSaysData>
                         {
                             new TextData
                             {
                                 Text = "I like hockey."
                             }
                         }
                    },
                    new UserSays
                    {
                        Data = new List<IUserSaysData>
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
                        Parameters = new List<ActionParameter>
                        {
                            new ActionParameter
                            {
                                DataType = "@sys.number",
                                Name = "amount",
                                Value = "$amount",
                                Prompts = new List<string> {"How much do you like hockey?"},
                                Required = true
                            }
                        },
                        Messages = new List<IntentMessage>
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
            var res = await dialogFlowService.CreateIntent(intent);
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
             CreateServer();
        }
        
    }

    public class MessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("Jess is SMEXY");
            return response;
        }
    }
}