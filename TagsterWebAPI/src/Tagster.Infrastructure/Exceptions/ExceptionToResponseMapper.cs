using System.Threading.Tasks;
using Tagster.Exception.Factories;
using Tagster.Exception.Mappers;
using Tagster.Exception.Models;

namespace Tagster.Infrastructure.Exceptions
{
    internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private readonly IExceptionResponseFactory _exceptionResponseFactory;

        public ExceptionToResponseMapper(IExceptionResponseFactory exceptionResponseFactory)
            => _exceptionResponseFactory = exceptionResponseFactory;

        public Task<ExceptionResponse> Map(System.Exception exception)
            => exception switch
            {
                DomainException ex => _exceptionResponseFactory.Create(ex),
                AppException ex => _exceptionResponseFactory.Create(ex),
                InfrastructureException ex => _exceptionResponseFactory.Create(ex),
                _ => _exceptionResponseFactory.Create("error", "There was an error")
            };
    }
}
