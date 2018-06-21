using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketGuardian.Net.Models
{
    public class CreatePolicyModel
    {
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("order_number")]
        public int OrderNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "USD";

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tickets")]
        public List<TicketModel> Tickets { get; set; }
    }
}
