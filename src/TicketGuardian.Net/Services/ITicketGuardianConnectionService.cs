using System.Threading.Tasks;

namespace TicketGuardian.Net.Services
{
    public interface ITicketGuardianConnectionService
    {
        Task<Models.TokenModel> GetAuthenticationToken();

        Task<Models.PagedListModel<Models.ClaimModel>> GetClaims();
        Task<Models.PagedListModel<Models.OrderModel>> GetOrders();

        Task<Models.PagedListModel<Models.ShipPolicyModel>> GetPolicies();
        Task<Models.ShipPolicyModel> GetPolicy(int pk);

        Task<Models.PagedListModel<Models.PriceTierModel>> GetPriceTiers();
        Task<Models.PriceTierModel> GetPriceTier(int pk);

        Task<Models.PagedListModel<Models.ProductModel>> GetProducts();
        Task<Models.ProductModel> GetProduct(int pk);

        Task<Models.PagedListModel<Models.TicketOrderModel>> GetTicketOrders();
        Task<Models.TicketOrderModel> PostTicketOrder(Models.ChargeOrderModel order);

        Task<Models.TicketOrderModel> PostTicketPolicy(Models.CreatePolicyModel policy);

        Task<Models.PagedListModel<Models.TransactionModel>> GetTransactions();
        Task<Models.TransactionModel> GetTransaction(int pk);
    }
}