using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketGuardian.Net.Infrastructure;
using TicketGuardian.Net.Models;

namespace TicketGuardian.Net.Services
{
    public class TicketGuardianConnectionService : ITicketGuardianConnectionService
    {
        #region Properties
        private HttpClient _httpClient { get; }
        private TicketGuardianSettings _settings { get; set; }
        private TokenModel _token { get; set; }
        #endregion

        #region ctors
        public TicketGuardianConnectionService(TicketGuardianSettings settings, HttpClient httpClient)
        {
            _settings = settings;
            _token = GetAuthenticationToken().Result;
            _httpClient = httpClient;
        }
        #endregion

        #region Methods
        public virtual async Task<TokenModel> GetAuthenticationToken()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/token";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("api-client-id", _settings.ClientId);
            request.Headers.Add("api-secret-key", _settings.SecretKey);
            request.Headers.Add("api-public-key", _settings.PublicKey);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TokenModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Claims
        public virtual async Task<PagedListModel<ClaimModel>> GetClaims()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/claims";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ClaimModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Orders
        public virtual async Task<PagedListModel<OrderModel>> GetOrders()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/orders";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<OrderModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Policies
        public virtual async Task<PagedListModel<ShipPolicyModel>> GetPolicies()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/policies";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ShipPolicyModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ShipPolicyModel> GetPolicy(int pk)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/policies/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ShipPolicyModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Price Tiers
        public virtual async Task<PagedListModel<PriceTierModel>> GetPriceTiers()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/pricetiers";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<PriceTierModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<PriceTierModel> GetPriceTier(int pk)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/pricetiers/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PriceTierModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Products
        public virtual async Task<PagedListModel<ProductModel>> GetProducts()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/products";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ProductModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ProductModel> GetProduct(int pk)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/products/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Ticket Orders
        public virtual async Task<PagedListModel<TicketOrderModel>> GetTicketOrders()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/ticket-orders";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<TicketOrderModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<TicketOrderModel> PostTicketOrder(ChargeOrderModel order)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/ticket-orders/";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = JsonContent(order)
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketOrderModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Ticket Policies
        public virtual async Task<TicketOrderModel> PostTicketPolicy(CreatePolicyModel policy)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/ticket-policies/";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = JsonContent(policy)
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketOrderModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Transactions
        public virtual async Task<PagedListModel<TransactionModel>> GetTransactions()
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/transactions";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<TransactionModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<TransactionModel> GetTransaction(int pk)
        {
            var url = $"{Urls.ApiUrl(_settings.SandboxEnabled)}/{_settings.ClientId}/transactions/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TransactionModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }
        #endregion

        #region Helpers
        void ApplyClientData()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("JWT", $"{_token.JwtToken}");
        }

        string GetAuthHeaders()
        {
            // TODO: Add check if the token has expired
            // Ticket Guardian tokens live for 3 minutes
            // check our Token.IssueDate against the current time (UTC)
            return $"JWT {_token.JwtToken}";
        }

        TicketGuardianException BuildException(HttpStatusCode statusCode, string requestUri, string responseContent)
        {
            var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);
            error.Url = requestUri;

            return new TicketGuardianException(statusCode, error, error.Message);
        }

        HttpContent JsonContent<T>(T item)
        {
            return new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
        }
        #endregion
    }
}