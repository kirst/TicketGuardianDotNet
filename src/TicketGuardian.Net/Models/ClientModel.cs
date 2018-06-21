using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ClientModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("policy_price")]
        public string PolicyPrice { get; set; }

        [JsonProperty("shopify_setting")]
        public object ShopifySetting { get; set; }
    }
}