using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Auth.Exceptions
{
    public class EmptyRefreshTokenException : DomainException
    {
        public override string Code { get; } = "empty_refresh_token";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public EmptyRefreshTokenException() : base("Empty refresh token.")
        {
        }
    }
}
