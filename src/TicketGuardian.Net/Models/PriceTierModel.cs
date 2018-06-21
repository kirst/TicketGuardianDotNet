using Newtonsoft.Json;
using TicketGuardian.Net.Infrastructure;

namespace TicketGuardian.Net.Models
{
    public class PriceTierModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order_min")]
        public string OrderMin { get; set; }

        [JsonProperty("order_max")]
        public string OrderMax { get; set; }

        [JsonProperty("wholesale_cost")]
        public string WholeSaleCost { get; set; }

        [JsonProperty("retail_cost")]
        public string RetailCost { get; set; }

        /// <summary>
        /// ['fixed' or 'percent']
        /// </summary>
        [JsonProperty("price_type")]
        public PriceTypes PriceType { get; set; }
    }
}