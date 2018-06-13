using System;
using System.Net;
using TicketGuardian.Net.Models;

namespace TicketGuardian.Net
{
    public class TicketGuardianException : Exception
    {
        #region Properties
        public HttpStatusCode HttpStatusCode { get; private set; }
        public ErrorResponseModel ErrorResponse { get; private set; }
        #endregion

        #region ctors
        public TicketGuardianException()
        {

        }

        public TicketGuardianException(HttpStatusCode statusCode, ErrorResponseModel error, string message) : base(message)
        {
            HttpStatusCode = statusCode;
            ErrorResponse = error;
        }
        #endregion
    }
}
