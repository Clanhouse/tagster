using Microsoft.Extensions.Logging;

namespace Tagster.Exception.Logger;

public static class LoggerExtension
{
    public static void LogException(this ILogger logger, System.Exception exception, int statusCode)
    {
        switch (statusCode)
        {
            case >= 500:
                logger.LogError(exception, "{message}", exception.Message);
                break;
            default:
                logger.LogWarning(exception, "{message}", exception.Message);
                break;
        }
    }
}
