using System.Net;

namespace Tagster.Exception.Models;

public abstract class InfrastructureException : BaseException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;

    public InfrastructureException(string message) : base(message)
    {
    }
}
