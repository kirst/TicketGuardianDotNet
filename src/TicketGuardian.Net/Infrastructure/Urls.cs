namespace TicketGuardian.Net.Infrastructure
{
    internal static class Urls
    {
        static string LiveApiUrl
        {
            get
            {
                return "https://connect.ticketguardian.net/api/v1";
            }
        }

        static string SandboxApiUrl
        {
            get
            {
                return "https://connect-test.ticketguardian.net/api/v1";
            }
        }

        public static string ApiUrl(bool sandboxEnabled)
        {
            return sandboxEnabled ? SandboxApiUrl : LiveApiUrl;
        }
    }
}