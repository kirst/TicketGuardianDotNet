using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class TicketPolicyTests
    {
        [Fact]
        public async Task Post_Policy()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            var policyModel = CreateTestPolicyModel();

            // Act
            var result = await ve.PostTicketPolicy(policyModel);

            // Assert
            var vr = Assert.IsType<Models.TicketOrderModel>(result);

            Assert.NotNull(vr);
            //Assert.Equal(vr.InsurancePolicies.Count, orderModel.Tickets.Count);
        }

        static Models.CreatePolicyModel CreateTestPolicyModel()
        {
            var rnd = new Random();

            var model = new Models.CreatePolicyModel()
            {
                Currency = "USD",
                Email = "paul@svetiming.com",
                FirstName = "Test",
                LastName = "Tester",
                OrderNumber = rnd.Next(100, 999),
                Tickets = Enumerable.Range(1, rnd.Next(1, 3)).Select(n => new Models.TicketModel()
                {
                    Cost = 30.00M,
                    Description = $"Ticket {n} - Test Tester"
                }).ToList()
            };

            return model;
        }
    }
}