using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class RevokedRefreshTokenException : AppException
{
    public override string Code { get; } = "revoked_refresh_token";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public RevokedRefreshTokenException() : base("Revoked refresh token.")
    {
    }
}
