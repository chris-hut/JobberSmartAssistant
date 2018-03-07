using System;
using System.Collections.Generic;
using DialogFlow.Sdk.Models;
using DialogFlow.Sdk.Services;
using Newtonsoft.Json;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new DialogFlowConfig
            {
                ApiKey = "7e0de8bad48542f9be2253a21cbebaaa"
            };

            var dialogFlowService = new DialogFlowServiceFactory(config).CreateDialogFlowService();

            var intent = new Intent
            {
                Name = "Testing",
                Templates = new string[] {"I like hockey!"},
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
                                IsRequired = true
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

            var res = dialogFlowService.CreateIntent(intent).Result;
            return;
        }
    }
}