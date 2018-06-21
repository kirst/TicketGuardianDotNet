using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class TicketModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }
    }
}