using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketGuardian.Net.Models
{
    public class TicketOrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("total_coverage_amount")]
        public string TotalCoverageAmount { get; set; }

        [JsonProperty("total_purchase_amount")]
        public string TotalPurchaseAmount { get; set; }
        
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("main_transaction")]
        public string MainTransaction { get; set; }

        [JsonProperty("insurance_policy")]
        public string InsurancePolicy { get; set; }
    }
}
