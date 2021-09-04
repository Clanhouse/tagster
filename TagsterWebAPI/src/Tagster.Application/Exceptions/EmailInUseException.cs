using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions
{
    public class EmailInUseException : AppException
    {
        public override string Code { get; } = "email_in_use";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
        public string Email { get; }

        public EmailInUseException(string email) : base($"Email {email} is already in use.")
        {
            Email = email;
        }
    }
}
