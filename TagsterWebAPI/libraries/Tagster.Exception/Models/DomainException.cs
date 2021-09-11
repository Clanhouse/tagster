using System.Net;
namespace Tagster.Exception.Models
{
    public abstract class DomainException : BaseException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public DomainException(string message) : base(message)
        {
        }
    }
}
