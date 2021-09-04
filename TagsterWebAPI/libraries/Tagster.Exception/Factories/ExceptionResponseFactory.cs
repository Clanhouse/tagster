using Tagster.Exception.Models;
using System.Net;
using System.Threading.Tasks;

namespace Tagster.Exception.Factories
{
    internal sealed class ExceptionResponseFactory : IExceptionResponseFactory
    {
        public Task<ExceptionResponse> Create(BaseException ex)
            => Task.FromResult(new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, ex.StatusCode));

        public Task<ExceptionResponse> Create(string code, string message,
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
            => Task.FromResult(new ExceptionResponse(new { code, reason = message }, httpStatusCode));

        public Task<ExceptionResponse> Create(object @object, HttpStatusCode httpStatusCode) 
            => Task.FromResult(new ExceptionResponse(@object, httpStatusCode));
    }
}
