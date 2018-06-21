using System;
using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class TokenModel
    {
        [JsonProperty("referer")]
        public string Referer { get; set; }

        [JsonProperty("jwt")]
        public string JwtToken { get; set; }

        [JsonIgnore]
        public DateTimeOffset IssueDate { get; private set; }

        public TokenModel()
        {
            IssueDate = DateTime.UtcNow;
        }
    }
}