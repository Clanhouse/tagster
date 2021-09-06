using Microsoft.Extensions.Logging;

namespace Tagster.Exception.Logger
{
    public static class LoggerExtension
    {
        public static void LogException(this ILogger logger, System.Exception exception, int statusCode)
        {
            switch (statusCode)
            {
                case >= 500:
<<<<<<< HEAD
                    logger.LogError(exception, exception.Message);
                    break;
                default:
                    logger.LogWarning(exception, exception.Message);
=======
                    logger.LogError(exception, "{message}", exception.Message);
                    break;
                default:
                    logger.LogWarning(exception, "{message}", exception.Message);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
                    break;
            }
        }
    }
}
