using System.Net;
using System.Threading.Tasks;
using Tagster.Exception.Models;

namespace Tagster.Exception.Factories;

public interface IExceptionResponseFactory
{
    /// <summary>
    /// Create exception response from base exception model
    /// </summary>
    /// <param name="baseException"></param>
    /// <returns></returns>
    public Task<ExceptionResponse> Create(BaseException baseException);

    /// <summary>
    /// Create exception response base on object model
    /// </summary>
    /// <param name="object"></param>
    /// <param name="httpStatusCode"></param>
    /// <returns></returns>
    public Task<ExceptionResponse> Create(object @object, HttpStatusCode httpStatusCode);

    /// <summary>
    /// Create exception response with default InsternalServerError status code
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task<ExceptionResponse> Create(string code, string message,
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError);
}
