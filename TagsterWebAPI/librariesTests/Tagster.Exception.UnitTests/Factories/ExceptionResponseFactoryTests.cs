using System.Threading.Tasks;
using Tagster.Exception.Factories;
using Tagster.Exception.Models;
using Xunit;
using Shouldly;

namespace Tagster.Exception.UnitTests.Factories
{
    public class ExceptionResponseFactoryTests
    {
        public IExceptionResponseFactory Factory { get; set; }
        public ExceptionResponseFactoryTests()
        {
            Factory = new ExceptionResponseFactory();
        }



        [Fact]
        public async Task Create_CreateExceptionResponseFromAppException_TypeShouldBeExceptionResponse()
        {
            
            var result = await Factory.Create(new TestException(""));

            result.ShouldBeAssignableTo(typeof(ExceptionResponse));
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("abnbsmnbhegygeyrgfur")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponseFromAppException_CodeShouldEqualExcepted(string excepted)
        {
            
            var result = await Factory.Create(new TestException2(excepted));

            result.Response.GetType().GetProperty(nameof(AppException.Code)).GetValue(result.Response, null).ShouldBe(excepted);

        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("abnbsmnbhegygeyrgfur")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponseFromAppException_ReasonShouldEqualExcepted(string excepted)
        {
            
            var result = await Factory.Create(new TestException3(excepted));

            result.Response.GetType().GetProperty("Reason").GetValue(result.Response, null).ShouldBe(excepted);

        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("abnbsmnbhegygeyrgfur")]
        [InlineData("!@#$%^&*()")]
        [InlineData("")]
        public async Task Create_CreateExceptionResponseFromAppException_StatusCodeShouldEqualExcepted(string excepted)
        {

            var result = await Factory.Create(new TestException4(excepted));

            result.Response.GetType().GetProperty(nameof(AppException.StatusCode)).GetValue(result.Response, null).ShouldBe(excepted);

        }
    }

    internal class TestException : AppException
    {
        public TestException(string message) : base(message)
        {
        }
    }

    internal class TestException2 : AppException
    {
        public override string Code { get; }

        public TestException2(string code) : base("")
        {
            Code = code;
        }
    }

    internal class TestException3 : AppException
    {
        public override string Message { get; }

        public TestException3(string message) : base("")
        {
            Message = message;
        }
    }

/*    internal class TestException4 : AppException
    {
        public override string Message { get; }

        public TestException4(string message) : base("")
        {
            Message = message;
        }
    }*/
}
