using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class AuthorizationTests
    {
        [Fact]
        public async Task Valid_JWT()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetAuthenticationToken();

            // Assert
            var vr = Assert.IsType<Models.TokenModel>(result);

            Assert.NotNull(vr);
            Assert.NotEmpty(vr.JwtToken);
        }

        [Theory]
        [InlineData("this-is-a-bad-key")]
        public async Task Bad_Public_Key(string badPublicKey)
        {
            // Arrange
            var appSettings = new TestAppSettings();
            appSettings.Value.PublicKey = badPublicKey;
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            var error = new TicketGuardianException(HttpStatusCode.Unauthorized, new Models.ErrorResponseModel(), "");

            // Act
            try
            {
                var result = await ve.GetAuthenticationToken();
            }
            catch(TicketGuardianException ex)
            {
                error = ex;
            }

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, error.HttpStatusCode);
            Assert.Equal("Bad Public Key or Secret Key.", error.Message);
        }
    }
}