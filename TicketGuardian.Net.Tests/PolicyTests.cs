using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class PolicyTests
    {
        [Fact]
        public async Task Has_Policy_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetPolicies();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.ShipPolicyModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }

        [Theory]
        [InlineData(338289)]
        public async Task Valid_Policy(int pk)
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetPolicy(pk);

            // Assert
            var vr = Assert.IsType<Models.ShipPolicyModel>(result);

            Assert.NotNull(vr);
            Assert.Equal(vr.Id, pk);
        }
    }
}