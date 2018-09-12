using System.Threading.Tasks;

namespace TicketGuardian.Net.Services
{
    public interface ITicketGuardianConnectionService
    {
        Task<Models.TokenModel> GetAuthenticationToken();
        Task<Models.PagedListModel<Models.OrderModel>> GetOrders();
        Task<Models.PagedListModel<Models.TicketOrderModel>> GetTicketOrders();
        Task<Models.TicketOrderModel> PostTicketOrder(Models.ChargeOrderModel order);
        Task<Models.TicketOrderModel> PostTicketPolicy(Models.CreatePolicyModel policy);
    }
}