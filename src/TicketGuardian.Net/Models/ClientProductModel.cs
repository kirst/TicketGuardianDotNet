using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ClientProductModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("object_id")]
        public int ObjectId { get; set; }
    }
}