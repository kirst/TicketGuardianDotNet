using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ErrorResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public string Url { get; set; }
    }
}