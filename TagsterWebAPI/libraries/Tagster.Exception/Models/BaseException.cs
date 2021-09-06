using System.Net;


namespace Tagster.Exception.Models
{
    public abstract class BaseException : System.Exception
    {
        public virtual string Code { get; }
        public virtual HttpStatusCode StatusCode { get; }

        public BaseException(string message) : base(message)
        {
        }
    }
}
