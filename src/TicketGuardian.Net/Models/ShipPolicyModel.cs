using Newtonsoft.Json;

namespace TicketGuardian.Net.Models
{
    public class ShipPolicyModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("billing_addr")]
        public AddressModel BillingAddress { get; set; }

        [JsonProperty("shipping_addr")]
        public AddressModel ShippingAddress { get; set; }

        [JsonProperty("client")]
        public ClientModel Client { get; set; }

        [JsonProperty("policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("items_ordered")]
        public string ItemsOrdered { get; set; }

        [JsonProperty("subtotal")]
        public string SubTotal { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("coverage_amount")]
        public string CoverageAmount { get; set; }

        [JsonProperty("order_number")]
        public string OrderId { get; set; }

        [JsonProperty("order_date")]
        public string OrderDate { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("ship_to_billing_addr")]
        public bool ShipToBillingAddress { get; set; }
    }
}