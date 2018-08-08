using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class ProductTests
    {
        [Fact]
        public async Task Has_Products_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetProducts();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.ProductModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }

        [Theory]
        [InlineData(1)]
        public async Task Valid_Product(int pk)
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetProduct(pk);

            // Assert
            var vr = Assert.IsType<Models.ProductModel>(result);

            Assert.NotNull(vr);
            Assert.Equal(vr.Id, pk);
        }
    }
}