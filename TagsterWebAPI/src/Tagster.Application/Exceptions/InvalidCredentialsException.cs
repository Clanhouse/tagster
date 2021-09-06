using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions
{
    public class InvalidCredentialsException : AppException
    {
        public override string Code { get; } = "invalid_credentials";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Unauthorized;
        public string Email { get; }

        public InvalidCredentialsException(string email) : base("Invalid credentials.")
        {
            Email = email;
        }
    }
}
