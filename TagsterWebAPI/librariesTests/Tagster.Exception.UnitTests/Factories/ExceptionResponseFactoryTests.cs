using System.Threading.Tasks;
using Tagster.Exception.Factories;
using Tagster.Exception.Models;
using Xunit;
using Shouldly;

namespace Tagster.Exception.UnitTests.Factories
{
    public class ExceptionResponseFactoryTests
    {
        [Fact]
        public async Task Create_CreateExceptionResponseFromAppException_TypeShouldBeExceptionResponse()
        {
            IExceptionResponseFactory factory = new ExceptionResponseFactory();

            var result = await factory.Create(new TestException(""));

            result.ShouldBeAssignableTo(typeof(ExceptionResponse));
        }

        //[Theory]
        //[InlineData("", "")]
        //public async Task Create_CreateExceptionResponseFromAppException_CodeShouldEqualExcepted(string excepted, string code)
        //{
        //    IExceptionResponseFactory factory = new ExceptionResponseFactory();

        //    var result = await factory.Create(new TestException2(code));

        //    result.Response.GetType().GetProperty("Code").GetValue(result, null).ShouldBe(excepted);
        //}
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
}
