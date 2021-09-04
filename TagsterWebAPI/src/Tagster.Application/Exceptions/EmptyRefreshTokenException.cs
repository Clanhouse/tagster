using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions
{
    public class EmptyRefreshTokenException : AppException
    {
        public override string Code { get; } = "empty_refresh_token";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public EmptyRefreshTokenException() : base("Empty refresh token.")
        {
        }
    }
}
