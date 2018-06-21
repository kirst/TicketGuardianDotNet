using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class TransactionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("charge_amount")]
        public string ChargeAmount { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("processor")]
        public string Processor { get; set; }
    }
}