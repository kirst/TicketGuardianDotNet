using Newtonsoft.Json;
using TicketGuardian.Net.Infrastructure;

namespace TicketGuardian.Net.Models
{
    public class ClaimModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("customers_name")]
        public string CustomersName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("event_id")]
        public int EventId { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("order_number")]
        public string OrderId { get; set; }

        [JsonProperty("filed")]
        public string Filed { get; set; }

        [JsonProperty("validated")]
        public string Validated { get; set; }

        /// <summary>
        /// Valid Values
        /// ['initiated' or 'paid' or 'docsrequired' or 'denied']
        /// </summary>
        [JsonProperty("status")]
        public ClaimStatuses Status { get; set; }

        [JsonProperty("policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty("client")]
        public string Client { get; set; }
    }
}