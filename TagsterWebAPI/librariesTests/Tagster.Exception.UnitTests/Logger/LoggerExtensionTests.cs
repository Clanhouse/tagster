using System;
using Microsoft.Extensions.Logging;
using Moq;
using Tagster.Exception.Logger;
using Xunit;

namespace Tagster.Exception.UnitTests.Logger
{
    public class LoggerExtensionTests
    {
        [Theory]
        [InlineData(500)]
        [InlineData(501)]
        [InlineData(502)]
        [InlineData(503)]
        [InlineData(504)]
        public void LogException_ServerErrorStatusCode_ShouldCallLogError(int statusCode)
        {
            var loggerMock = new Mock<ILogger>();

            var exception = new System.Exception("Message");
            loggerMock.Object.LogException(exception, statusCode);

            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<System.Exception>(),
                    It.Is<Func<It.IsAnyType, System.Exception, string>>((v, t) => true)));
        }

        [Theory]
        [InlineData(200)]
        [InlineData(201)]
        [InlineData(300)]
        [InlineData(400)]
        [InlineData(401)]
        public void LogException_OtherStatusCodes_ShouldCallLogWarning(int statusCode)
        {
            var loggerMock = new Mock<ILogger>();

            var exception = new System.Exception("Message");
            loggerMock.Object.LogException(exception, statusCode);

            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<System.Exception>(),
                    It.Is<Func<It.IsAnyType, System.Exception, string>>((v, t) => true)));
        }

        [Theory]
        [InlineData(500)]
        [InlineData(400)]
        [InlineData(200)]
        public void LogException_AnyStatusCode_ShouldPassExceptionMessage(int statusCode)
        {
            var loggerMock = new Mock<ILogger>();

            var exception = new System.Exception("Message");
            loggerMock.Object.LogException(exception, statusCode);

            loggerMock.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString() == exception.Message),
                    It.IsAny<System.Exception>(),
                    It.Is<Func<It.IsAnyType, System.Exception, string>>((v, t) => true)));
        }
    }
}