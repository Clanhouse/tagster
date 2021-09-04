using Microsoft.Extensions.Logging;

namespace Tagster.Exception.Logger
{
    public static class LoggerExtension
    {
        public static void LogException(this ILogger logger, System.Exception exception, int statusCode)
        {
            if (statusCode >= 500)
                logger.LogError(exception, exception.Message);
            else
                logger.LogWarning(exception, exception.Message);
        } 
    }
}
