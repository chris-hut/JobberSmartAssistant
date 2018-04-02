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

        public LineItem WithUnitCost(double unitCost)
        {
            return new LineItem
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Qty = Qty,
                UnitCost = unitCost.ToString()
            };
        }
    }
}
