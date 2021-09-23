using System.Threading.Tasks;

namespace Tagster.Application.Services
{
    public interface IAdminService
    {
        public Task CreateFakeDataAsync(int profilesCount, int maxTagsPerProfile);
    }
}
