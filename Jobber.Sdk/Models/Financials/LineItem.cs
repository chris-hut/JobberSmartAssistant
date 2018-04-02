using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Financials
{
    public class LineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }
        
        [JsonProperty("unit_cost")]
        public string UnitCost { get; set; }
        
        [JsonProperty("cost")]
        public string Cost { get; set; }

        public LineItem WithCost(double cost)
        {
            return new LineItem
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Qty = Qty,
                Cost = cost.ToString(),
                UnitCost = UnitCost
            };
        }
    }
}
