using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class InvalidRefreshTokenException : AppException
{
    public override string Code { get; } = "invalid_refresh_token";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public InvalidRefreshTokenException() : base("Invalid refresh token.")
    {
    }
}
