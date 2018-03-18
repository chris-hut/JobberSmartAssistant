using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Clients
{
    public class Properties
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("street1")]
        public string Street1 { get; set; }

        [JsonProperty("street2")]
        public string Street2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("map_address")]
        public string MapAddress { get; set; }
    }
}
