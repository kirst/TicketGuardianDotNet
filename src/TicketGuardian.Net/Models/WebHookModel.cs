using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class WebHookModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Available Actions
        /// ['osis-policy-created' or 'osis-claim-filed' or 'osis-claim-validated' or 'eventbrite-order-placed']
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("client")]
        public string Client { get; set; }
    }
}