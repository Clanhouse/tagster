using System.Threading.Tasks;
using Tagster.Exception.Models;

namespace Tagster.Exception.Mappers
{
    public interface IExceptionToResponseMapper
    {
        Task<ExceptionResponse> Map(System.Exception exception);
    }
}
