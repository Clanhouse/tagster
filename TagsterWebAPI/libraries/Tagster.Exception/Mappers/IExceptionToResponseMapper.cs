using Tagster.Exception.Models;
using System.Threading.Tasks;

namespace Tagster.Exception.Mappers
{
    public interface IExceptionToResponseMapper
    {
        Task<ExceptionResponse> Map(System.Exception exception);
    }
}
