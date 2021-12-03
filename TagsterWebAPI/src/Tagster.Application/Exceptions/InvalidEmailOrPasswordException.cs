using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class InvalidEmailOrPasswordException : AppException
{
    public override string Code { get; } = "invalid_email_or_password";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public InvalidEmailOrPasswordException(string email) : base($"Invalid email: {email} or password.")
    {
    }
}
