namespace TicketGuardian.Net.Infrastructure
{
    internal static class Urls
    {
        static string LiveApiUrl
        {
            get
            {
                return "https://connect.ticketguardian.net/api/v2";
            }
        }

        static string SandboxApiUrl
        {
            get
            {
                return "https://connect-sandbox.ticketguardian.net/api/v2";
            }
        }

        public static string ApiUrl(bool sandboxEnabled)
        {
            return sandboxEnabled ? SandboxApiUrl : LiveApiUrl;
        }
    }
}