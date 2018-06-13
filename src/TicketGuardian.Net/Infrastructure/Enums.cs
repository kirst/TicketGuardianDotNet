using System.ComponentModel;

namespace TicketGuardian.Net.Infrastructure
{
    public enum PriceTypes
    {
        [Description("Fixed")]
        @fixed,
        [Description("Percent")]
        percent
    }

    public enum ClaimStatuses
    {
        [Description("Initiated")]
        initiated,
        [Description("Paid")]
        paid,
        [Description("Docs Required")]
        docsrequired,
        [Description("Denied")]
        denied
    }
}