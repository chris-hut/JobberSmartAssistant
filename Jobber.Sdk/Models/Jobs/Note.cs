using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class Note
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
