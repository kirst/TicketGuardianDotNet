using Newtonsoft.Json;
using System;
using System.Linq;
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
        private readonly HttpClient _httpClient;
        private readonly TicketGuardianSettings _settings;
        private TokenModel _token { get; set; }
        #endregion

        #region ctors
        public TicketGuardianConnectionService(TicketGuardianSettings settings, HttpClient httpClient)
        {
            _settings = settings;
            _httpClient = httpClient;
        }
        #endregion

        #region Methods
        public virtual async Task<TokenModel> GetAuthenticationToken()
        {
            var builder = new UriBuilder($"{Urls.ApiUrl(_settings.SandboxEnabled)}/auth/token");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("TG-Version", "2.0.0");

            var js = new
            {
                public_key = _settings.PublicKey,
                secret_key = _settings.SecretKey
            };

            var request = new HttpRequestMessage(HttpMethod.Post, builder.ToString())
            {
                Content = JsonContent(js)
            };

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);

            if (response.IsSuccessStatusCode)
            {
                _token = JsonConvert.DeserializeObject<TokenModel>(await response.Content.ReadAsStringAsync());
                return _token;
            }
            
            throw BuildException(response.StatusCode, builder.ToString(), await response.Content.ReadAsStringAsync());
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
        #endregion

        #region Helpers
        private void ApplyClientData()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("JWT", $"{_token.JwtToken}");
        }

        private string GetAuthHeaders()
        {
            // TODO: Add check if the token has expired
            // Ticket Guardian tokens live for 3 minutes
            // check our Token.IssueDate against the current time (UTC)
            return $"JWT {_token.JwtToken}";
        }

        private TicketGuardianException BuildException(HttpStatusCode statusCode, string requestUri, string responseContent)
        {
            var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);
            error.Url = requestUri;

            return new TicketGuardianException(statusCode, error, error?.NonFieldErrors?.FirstOrDefault() ?? error?.Message);
        }

        private HttpContent JsonContent<T>(T item)
        {
            return new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
        }
        #endregion
    }
}