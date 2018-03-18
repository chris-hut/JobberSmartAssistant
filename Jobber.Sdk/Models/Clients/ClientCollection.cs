using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Clients
{
    public class ClientCollection
    {
        [JsonProperty("clients")] 
        public IEnumerable<Client> Clients { get; set; } = new List<Client>();

        public int Count => Clients.Count();
    }
}