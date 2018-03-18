using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class Assigned
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
