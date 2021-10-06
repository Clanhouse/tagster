using System.Threading.Tasks;
using Tagster.Exception.Factories;
using Tagster.Exception.Models;
using Xunit;
using Shouldly;
using System.Net;

namespace Tagster.Exception.UnitTests.Factories
{
    public class ExceptionResponseFactoryTests
    {
        private readonly IExceptionResponseFactory _factory;
        public ExceptionResponseFactoryTests() => _factory = new ExceptionResponseFactory();

        [Fact]
        public async Task Create_CreateExceptionResponseFromAppException_TypeShouldBeExceptionResponse()
            => (await _factory.Create(new TestException(""))).ShouldBeAssignableTo(typeof(ExceptionResponse));

        [Theory]
        [InlineData("123456789")]
        [InlineData("abnbsmnbhegygeyrgfur")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponseFromAppException_CodeShouldEqualExcepted(string excepted)
        {
            var exception = await _factory.Create(new TestException(code: excepted));
            exception.Response.GetType().GetProperty(nameof(AppException.Code)).GetValue(exception.Response, null).ShouldBe(excepted);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("abnbsmnbhegygeyrgfur")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponseFromAppException_ReasonShouldEqualExcepted(string excepted)
        {
            var exception = await _factory.Create(new TestException(message: excepted));
            exception.Response.GetType().GetProperty("Reason").GetValue(exception.Response, null).ShouldBe(excepted);
        }

        [Theory]
        [InlineData(HttpStatusCode.Accepted)]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task Create_CreateExceptionResponseFromAppException_StatusCodeShouldEqualExcepted(HttpStatusCode excepted)
        {
            var exception = await _factory.Create(new TestException(excepted));
            exception.GetType().GetProperty(nameof(ExceptionResponse.StatusCode)).GetValue(exception, null).ShouldBe(excepted);
        }

        [Fact]
        public async Task Create_CreateExceptionResponsePassingCodeMessageAndHttpStatusCode_TypeShouldBeExceptionResponse()
            => (await _factory.Create("", "")).ShouldBeAssignableTo(typeof(ExceptionResponse));

        [Theory]
        [InlineData("username_exception")]
        [InlineData("password_exception")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponsePassingCodeMessageAndHttpStatusCode_CodeShouldEqualExcepted(string excepted)
        {
            var exception = await _factory.Create(excepted, "");
            exception.Response.GetType().GetProperty(nameof(AppException.Code)).GetValue(exception.Response, null).ShouldBe(excepted);
        }

        [Theory]
        [InlineData("username_exception")]
        [InlineData("password_exception")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponsePassingCodeMessageAndHttpStatusCode_ReasonShouldEqualExcepted(string excepted)
        {
            var exception = await _factory.Create("", excepted);
            exception.Response.GetType().GetProperty("Reason").GetValue(exception.Response, null).ShouldBe(excepted);
        }

        [Theory]
        [InlineData(HttpStatusCode.Accepted)]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task Create_CreateExceptionResponsePassingCodeMessageAndHttpStatusCode_StatusCodeShouldEqualExcepted(HttpStatusCode excepted)
        {
            var exception = await _factory.Create("", "", excepted);
            exception.GetType().GetProperty(nameof(ExceptionResponse.StatusCode)).GetValue(exception, null).ShouldBe(excepted);
        }
        /*
                [Fact] // Test of third method.
                public async Task Create_CreateExceptionResponseFromAppException_TypeShouldBeObjectAndHttpStatusCodeExceptionResponse()
                    => (await _factory.Create(new TestException())).ShouldBeAssignableTo(typeof(ExceptionResponse));
                [Theory]
                [InlineData(HttpStatusCode.Accepted)]
                [InlineData(HttpStatusCode.OK)]
                [InlineData(HttpStatusCode.Forbidden)]
                [InlineData(HttpStatusCode.InternalServerError)]

                public async Task Create_CreateExceptionResponsePassingHttpStatusCode_StatusCodeShouldEqualExcepted(HttpStatusCode excepted)
                {
                    var exception = await _factory.Create(2);
                    exception.GetType().GetProperty(nameof(ExceptionResponse.StatusCode)).GetValue(exception, null).ShouldBe(excepted);
                }*/

    }

    internal class TestException : AppException
    {
        public override string Code { get; }
        public override string Message { get; }
        public override HttpStatusCode StatusCode { get; }


        public TestException(string message = "", string code = "") : base(message)
        {
            Message = message;
            Code = code;
        }

        public TestException(HttpStatusCode statusCode) : base("")
            => StatusCode = statusCode;
    }
}
