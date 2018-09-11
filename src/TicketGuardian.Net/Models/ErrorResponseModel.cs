using System.Collections.Generic;
using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ErrorResponseModel
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }        

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonIgnore]
        public string Url { get; set; }

        [JsonProperty("non_field_errors")]
        public IEnumerable<string> NonFieldErrors { get; set; }

        [JsonProperty("errors")]
        public IEnumerable<ErrorModel> Errors { get; set; }
    }
}