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
        HttpClient Client => new HttpClient();
        TicketGuardianSettings Settings { get; set; }
        TokenModel Token { get; set; }
        #endregion

        #region ctors
        public TicketGuardianConnectionService(TicketGuardianSettings settings)
        {
            Settings = settings;
            Token = GetAuthenticationToken().Result;
        }
        #endregion

        #region Methods
        public virtual async Task<TokenModel> GetAuthenticationToken()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/token";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("api-client-id", Settings.ClientId);
            request.Headers.Add("api-secret-key", Settings.SecretKey);
            request.Headers.Add("api-public-key", Settings.PublicKey);

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TokenModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Claims
        public virtual async Task<PagedListModel<ClaimModel>> GetClaims()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/claims";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ClaimModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Orders
        public virtual async Task<PagedListModel<OrderModel>> GetOrders()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/orders";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<OrderModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Policies
        public virtual async Task<PagedListModel<ShipPolicyModel>> GetPolicies()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/policies";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ShipPolicyModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ShipPolicyModel> GetPolicy(int pk)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/policies/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ShipPolicyModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Price Tiers
        public virtual async Task<PagedListModel<PriceTierModel>> GetPriceTiers()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/pricetiers";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<PriceTierModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<PriceTierModel> GetPriceTier(int pk)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/pricetiers/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PriceTierModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Products
        public virtual async Task<PagedListModel<ProductModel>> GetProducts()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/products";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<ProductModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ProductModel> GetProduct(int pk)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/products/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Ticket Orders
        public virtual async Task<PagedListModel<TicketOrderModel>> GetTicketOrders()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/ticket-orders";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<TicketOrderModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<TicketOrderModel> PostTicketOrder(ChargeOrderModel order)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/ticket-orders/";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = JsonContent(order)
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketOrderModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Ticket Policies
        public virtual async Task<TicketOrderModel> PostTicketPolicy(CreatePolicyModel policy)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/ticket-policies/";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = JsonContent(policy)
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TicketOrderModel>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        // Transactions
        public virtual async Task<PagedListModel<TransactionModel>> GetTransactions()
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/transactions";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PagedListModel<TransactionModel>>(await response.Content.ReadAsStringAsync());
            }

            throw BuildException(response.StatusCode, url, await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<TransactionModel> GetTransaction(int pk)
        {
            var url = $"{Urls.ApiUrl(Settings.SandboxEnabled)}/{Settings.ClientId}/transactions/{pk}";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Authorization", GetAuthHeaders());

            var response = await Client.SendAsync(request);

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
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("JWT", $"{Token.JwtToken}");
        }

        string GetAuthHeaders()
        {
            // TODO: Add check if the token has expired
            // Ticket Guardian tokens live for 3 minutes
            // check our Token.IssueDate against the current time (UTC)
            return $"JWT {Token.JwtToken}";
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