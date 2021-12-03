using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Tagster.CQRS.Behaviors;

internal sealed class RequestLogingBehavior<TCommandOrQuery, TResult> : IPipelineBehavior<TCommandOrQuery, TResult>
{
    private readonly ILogger<RequestLogingBehavior<TCommandOrQuery, TResult>> _logger;

    public RequestLogingBehavior(ILogger<RequestLogingBehavior<TCommandOrQuery, TResult>> logger)
        => _logger = logger;

    public async Task<TResult> Handle(TCommandOrQuery commandOrQuery,
        CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
    {
        Stopwatch sw = new();
        var requestType = typeof(TCommandOrQuery);
        TResult response;
        try
        {
            _logger.LogInformation("Start processing {name}", requestType.Name);
            sw.Start();
            LogData(commandOrQuery);
            response = await next();
            sw.Stop();
            LogData(response);
            _logger.LogInformation("End processing {name} in {elapsedMilliseconds}ms", requestType.Name, sw.ElapsedMilliseconds);
        }
        catch (System.Exception ex)
        {
            sw.Stop();
            _logger.LogWarning("End processing {name} in {elapsedMilliseconds}ms. With exception {exception}",
                requestType.Name, sw.ElapsedMilliseconds, ex.Message);
            throw;
        }
        return response;
    }

    private void LogData(object @object)
    {
        if (@object is null)
        {
            return;
        }

        _logger.LogInformation("Log data {name}", @object.GetType().Name);
    }
}
