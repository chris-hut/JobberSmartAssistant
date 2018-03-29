using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class UserCollection
    {
        [JsonProperty("user")]
        public User Users { get; set; }

    }
}
