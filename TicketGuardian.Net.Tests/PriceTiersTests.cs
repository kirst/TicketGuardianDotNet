using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class PriceTiersTests
    {
        [Fact]
        public async Task Has_PriceTiers_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetPriceTiers();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.PriceTierModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }

        [Theory]
        [InlineData(2)]
        public async Task Valid_PriceTier(int pk)
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetPriceTier(pk);

            // Assert
            var vr = Assert.IsType<Models.PriceTierModel>(result);

            Assert.NotNull(vr);
            Assert.Equal(vr.Id, pk);
        }
    }
}