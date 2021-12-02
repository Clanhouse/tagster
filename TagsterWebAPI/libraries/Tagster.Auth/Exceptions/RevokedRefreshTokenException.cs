using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Auth.Exceptions;

public class RevokedRefreshTokenException : DomainException
{
    public override string Code { get; } = "revoked_refresh_token";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public RevokedRefreshTokenException() : base("Revoked refresh token.")
    {
    }
}
