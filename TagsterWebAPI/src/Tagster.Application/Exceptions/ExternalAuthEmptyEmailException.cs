using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class ExternalAuthEmptyEmailException : AppException
{
    public override string Code { get; } = "external_auth_empty_email";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public ExternalAuthEmptyEmailException() : base($"External auth empty email.")
    {
    }
}
