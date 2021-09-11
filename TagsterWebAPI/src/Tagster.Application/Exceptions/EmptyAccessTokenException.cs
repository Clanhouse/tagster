using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions
{
    public class EmptyAccessTokenException : AppException
    {
        public override string Code { get; } = "empty_access_token";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public EmptyAccessTokenException() : base("Empty access token.")
        {

        }
    }
}
