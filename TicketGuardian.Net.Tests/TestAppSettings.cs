using Microsoft.Extensions.Options;

namespace TicketGuardian.Net.Tests
{
    public class TestAppSettings : IOptions<TicketGuardianSettings>
    {
        private readonly TicketGuardianSettings _appSettings;

        public TestAppSettings(bool storeInCache = true)
        {
            _appSettings = new TicketGuardianSettings();
        }

        public TicketGuardianSettings Value
        {
            get
            {
                return _appSettings;
            }
        }
    }
}