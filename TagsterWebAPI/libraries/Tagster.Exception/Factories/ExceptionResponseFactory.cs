using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tagster.Exception.Models;

[assembly: InternalsVisibleTo("Tagster.Exception.UnitTests")]
namespace Tagster.Exception.Factories
{
    internal sealed class ExceptionResponseFactory : IExceptionResponseFactory
    {
        public Task<ExceptionResponse> Create(BaseException ex)
        {
            return Task.FromResult(new ExceptionResponse(new { Code = ex.Code, Reason = ex.Message }, ex.StatusCode));
        }

        public Task<ExceptionResponse> Create(string code, string message,
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            return Task.FromResult(new ExceptionResponse(new { Code = code, Reason = message }, httpStatusCode));
        }

        public Task<ExceptionResponse> Create(object @object, HttpStatusCode httpStatusCode)
        {
            return Task.FromResult(new ExceptionResponse(@object, httpStatusCode));
        }
    }
}
