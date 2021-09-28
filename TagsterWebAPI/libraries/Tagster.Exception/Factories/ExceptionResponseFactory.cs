using System.Net;
using System.Threading.Tasks;
using Tagster.Exception.Models;

namespace Tagster.Exception.Factories
{
    public sealed class ExceptionResponseFactory : IExceptionResponseFactory
    {
        public Task<ExceptionResponse> Create(BaseException ex)
        {
            return Task.FromResult(new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, ex.StatusCode));
        }

        public Task<ExceptionResponse> Create(string code, string message,
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            return Task.FromResult(new ExceptionResponse(new { code, reason = message }, httpStatusCode));
        }

        public Task<ExceptionResponse> Create(object @object, HttpStatusCode httpStatusCode)
        {
            return Task.FromResult(new ExceptionResponse(@object, httpStatusCode));
        }
    }
}
