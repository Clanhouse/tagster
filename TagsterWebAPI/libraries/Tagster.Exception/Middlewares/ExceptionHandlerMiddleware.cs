using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Tagster.Exception.Logger;
using Tagster.Exception.Mappers;

namespace Tagster.Exception.Middlewares
{
    public sealed class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly JsonSerializerOptions _serializerOptions;

        public ExceptionHandlerMiddleware(IExceptionToResponseMapper exceptionToResponseMapper,
            ILogger<ExceptionHandlerMiddleware> logger, JsonSerializerOptions serializerOptions)
        {
            _exceptionToResponseMapper = exceptionToResponseMapper;
            _logger = logger;
            _serializerOptions = serializerOptions;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, System.Exception exception)
        {
            var exceptionResponse = await _exceptionToResponseMapper.Map(exception);
            if (exceptionResponse is null)
            {
                _logger.LogWarning(exception, exception.Message);
                await context.Response.WriteAsync(string.Empty);
                return;
            }
            var statusCode = (int)(exceptionResponse?.StatusCode ?? HttpStatusCode.BadRequest);
            
            _logger.LogException(exception, statusCode);
            
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var result = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(exceptionResponse?.Response, _serializerOptions));
            await context.Response.Body.WriteAsync(result);
        }
    }
}