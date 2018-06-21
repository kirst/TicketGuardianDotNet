using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketGuardian.Net.Models
{
    public class ChargeOrderModel
    {
        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_zip_code")]
        public string BillingZipCode { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("ship_to_billing_addr")]
        public bool ShipToBillingAddress { get; set; } = true;

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("order_number")]
        public int OrderNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = "USD";

        [JsonProperty("items_ordered")]
        public string ItemsOrdered { get; set; }

        [JsonProperty("charge_amount")]
        public decimal ChargeAmount { get; set; }

        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("card_expire_month")]
        public int ExpMonth { get; set; }

        [JsonProperty("card_expire_year")]
        public int ExpYear { get; set; }

        [JsonProperty("card_ccv")]
        public string CCV { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tickets")]
        public List<TicketModel> Tickets { get; set; }
    }
}