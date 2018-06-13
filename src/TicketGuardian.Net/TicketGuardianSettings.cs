#if NETSTANDARD2_0
using Microsoft.Extensions.Configuration;
using System.IO;
#endif

namespace TicketGuardian.Net
{
    public class TicketGuardianSettings
    {
        #region Properties
        public string ClientId { get; set; }
        public string PublicKey { get; set; }
        public string SecretKey { get; set; }
        public bool SandboxEnabled { get; set; }
        #endregion

        #region ctors
        public TicketGuardianSettings()
        {
            var sandBoxEnabled = false;

#if NETSTANDARD2_0
            // http://stackoverflow.com/questions/27382481/why-visual-studio-tell-me-that-addjsonfile-method-is-not-define-in-configurati

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("ticketguardiansettings.json");

            var config = builder.Build();
            ClientId = config.GetSection("TicketGuardianSettings:ClientId").Value;
            PublicKey = config.GetSection("TicketGuardianSettings:PublicKey").Value;
            SecretKey = config.GetSection("TicketGuardianSettings:SecretKey").Value;

            
            bool.TryParse(config.GetSection("TickettGuardianSettings:SandboxEnabled").Value, out sandBoxEnabled);
#else
            ClientId = System.Configuration.ConfigurationManager.AppSettings["TicketGuardianSettings-ClientId"];
            PublicKey = System.Configuration.ConfigurationManager.AppSettings["TicketGuardianSettings-PublicKey"];
            SecretKey = System.Configuration.ConfigurationManager.AppSettings["TicketGuardianSettings-SecretKey"];

            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["TicketGuardianSettings-SandboxEnabled"], out sandBoxEnabled);
#endif

            SandboxEnabled = sandBoxEnabled;
        }
        #endregion
    }
}