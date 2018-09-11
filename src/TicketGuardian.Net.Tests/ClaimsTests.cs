using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class ClaimsTests
    {
        [Fact]
        public async Task Has_Claims_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetClaims();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.ClaimModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }
    }
}