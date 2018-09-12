using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class AuthorizationTests
    {
        [Theory]
        [InlineData("this-is-a-bad-key")]
        public async Task Bad_Public_Key(string badPublicKey)
        {
            // Arrange
            var appSettings = new TestAppSettings();
            appSettings.Value.PublicKey = badPublicKey;
            var ve = new TicketGuardianTestConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
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