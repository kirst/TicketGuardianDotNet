using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketGuardian.Net.Models
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main_transaction")]
        public TransactionModel MainTransaction { get; set; }

        [JsonProperty("insurance_transaction")]
        public TransactionModel InsuranceTransaction { get; set; }

        [JsonProperty("insurance_policy")]
        public ShipPolicyModel InsurancePolicy { get; set; }

        [JsonProperty("insurance_transaction_amount")]
        public string InsuranceTransactionAmount { get; set; }

        [JsonProperty("insurance_policy_amount ")]
        public string InsurancePolicyAmount { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("insurance_policies")]
        public IList<string> InsurancePolicies { get; set; }
    }
}