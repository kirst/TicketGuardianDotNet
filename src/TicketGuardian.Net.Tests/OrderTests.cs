using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class OrderTests
    {
        [Fact]
        public async Task Has_Order_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetOrders();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.OrderModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }        
    }
}