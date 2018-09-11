using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ErrorModel
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}