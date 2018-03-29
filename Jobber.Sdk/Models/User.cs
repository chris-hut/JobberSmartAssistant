using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uuid")]
        public string  Uuid { get; set; }

        [JsonProperty("current_user")]
        public bool CurrentUser { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("permissions")]
        public IEnumerable<Permission> MyPermissions { get; set; }

        public IDictionary<string, string> PossibleActions()
        {
            IDictionary<string, string> actions = new Dictionary<string, string>();

            foreach(Permission permission in MyPermissions)
            {
                switch (permission.Name)
                {
                    case "invoices":
                        if (permission.Read)
                        {
                            actions.Add("invoices", "Ready invoices");
                        }
                        break;
                    case "quotes":
                        if(permission.Read)
                        {
                            actions.Add("quotes", "Ready quotes");
                        }
                        break;
                    case "jobs":
                        if(permission.Create)
                        {
                            actions.Add("create jobs", "Create a job");
                        }
                        if(permission.List)
                        {
                            actions.Add("list visits", "Get my visits for today");
                        }
                        if(permission.Manage)
                        {
                            actions.Add("manage visits", "Unassigned visits for today");
                            actions.Add("completeable visits", "Completable visits");
                        }
                        break;
                    case "transactions":
                        if(permission.Read)
                        {
                            actions.Add("transactions", "How much money we made");
                        }
                        break;
                }
            }

            return actions;
        }
    }
}
