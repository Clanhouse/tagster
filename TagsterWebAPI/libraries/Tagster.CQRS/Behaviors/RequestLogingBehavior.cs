using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Tagster.CQRS.Behaviors
{
    internal sealed class RequestLogingBehavior<TCommandOrQuery, TResult> : IPipelineBehavior<TCommandOrQuery, TResult>
    {
        readonly ILogger<RequestLogingBehavior<TCommandOrQuery, TResult>> _logger;

        public RequestLogingBehavior(ILogger<RequestLogingBehavior<TCommandOrQuery, TResult>> logger)
            => _logger = logger;

        public async Task<TResult> Handle(TCommandOrQuery commandOrQuery,
            CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
        {
            Stopwatch sw = new();
            var requestType = typeof(TCommandOrQuery);
            _logger.LogInformation("Start processing {name}", requestType.Name);
            sw.Start();
            LogData(commandOrQuery);
            var response = await next();
            sw.Stop();
            LogData(response);
            _logger.LogInformation("End processing {name} in {elapsedMilliseconds}ms", requestType.Name, sw.ElapsedMilliseconds);
            return response;
        }

        private void LogData(object @object)
        {
            if (@object is null)
                return;

            _logger.LogInformation("Log data {name}", @object.GetType().Name);
        }
    }
}
