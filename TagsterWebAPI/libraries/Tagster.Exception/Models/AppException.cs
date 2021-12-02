using System.Net;

namespace Tagster.Exception.Models;

public abstract class AppException : BaseException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public AppException(string message) : base(message)
    {
    }
}
