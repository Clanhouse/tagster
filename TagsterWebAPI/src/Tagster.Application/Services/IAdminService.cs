using System.Threading.Tasks;
using Tagster.Application.Commands.GenFakeData;

namespace Tagster.Application.Services
{
    public interface IAdminService
    {
        public Task CreateFakeDataAsync(GenFakeData request);
    }
}
