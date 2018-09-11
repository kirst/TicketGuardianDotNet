using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TicketGuardian.Net.Tests
{
    public class TicketOrderTests
    {
        #region Properties
        const string FAKE_VISA_CARD = "4111111111111111";
        #endregion

        [Fact]
        public async Task Has_TicketOrder_List()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            // Act
            var result = await ve.GetTicketOrders();

            // Assert
            var vr = Assert.IsType<Models.PagedListModel<Models.TicketOrderModel>>(result);

            Assert.NotNull(vr);
            Assert.NotNull(vr.Results);
        }

        [Fact]
        public async Task Post_Order()
        {
            // Arrange
            var appSettings = new TestAppSettings();
            var ve = new Services.TicketGuardianConnectionService(appSettings.Value, new System.Net.Http.HttpClient());
            var orderModel = CreateTestOrderModel();

            // Act
            var result = await ve.PostTicketOrder(orderModel);

            // Assert
            var vr = Assert.IsType<Models.TicketOrderModel>(result);

            Assert.NotNull(vr);
            //Assert.Equal(vr.InsurancePolicies.Count, orderModel.Tickets.Count);
        }

        static Models.ChargeOrderModel CreateTestOrderModel()
        {
            var rnd = new Random();

            var model = new Models.ChargeOrderModel()
            {
                BillingAddress = "18330 Sutter Blvd",
                BillingCity = "Morgan Hill",
                BillingCountry = "USA",
                BillingState = "CA",
                BillingZipCode = "95037",
                CardNumber = FAKE_VISA_CARD,
                ChargeAmount = 5.99M,
                Currency = "USD",                
                CCV = "123",
                Email = "paul@svetiming.com",                
                ExpMonth = 6,
                ExpYear = DateTime.Now.Year + 1,
                FirstName = "Test",
                ItemsOrdered = "Test Items",
                LastName = "Tester",
                OrderNumber = rnd.Next(100, 999),
                ShipToBillingAddress = true,
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