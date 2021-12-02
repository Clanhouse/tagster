using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Tagster.Exception.Mappers;
using Tagster.Exception.Middlewares;
using Xunit;

namespace Tagster.Exception.UnitTests.Middlewares;

public class ExceptionHandlerMiddlewareTests
{
    private readonly Mock<IExceptionToResponseMapper> _exceptionToResponseMapperMock = new();
    private readonly Mock<ILogger<ExceptionHandlerMiddleware>> _loggerMock = new();

    [Fact]
    public async Task HandleErrorAsync_NullExceptionResponse_ShouldCallLoggerWithWarning()
    {
        var context = new DefaultHttpContext();

        var sut = new ExceptionHandlerMiddleware(
                _exceptionToResponseMapperMock.Object,
                _loggerMock.Object,
                new JsonSerializerOptions()
            );

        await sut.InvokeAsync(context, _ => throw new System.Exception("msg"));

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<System.Exception>(),
                It.Is<Func<It.IsAnyType, System.Exception, string>>((v, t) => true)));
    }

    [Fact]
    public async Task HandleErrorAsync_NullExceptionResponse_ShouldWriteEmptyStringToResponse()
    {
        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        var sut = new ExceptionHandlerMiddleware(
            _exceptionToResponseMapperMock.Object,
            _loggerMock.Object,
            new JsonSerializerOptions()
        );

        await sut.InvokeAsync(context, _ => throw new System.Exception("msg"));

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(context.Response.Body);
        var text = await reader.ReadToEndAsync();

        text.ShouldBeEmpty();
    }
}
