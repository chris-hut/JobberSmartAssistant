using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Clients;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class ClientsResponse
    {
        [JsonProperty("clients")] 
        public IEnumerable<Client> Clients { get; set; } = new List<Client>();

        public int Count => Clients.Count();
    }
}