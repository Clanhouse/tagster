using System.Threading.Tasks;
using Tagster.Application.Dtos.Requests;

namespace Tagster.Application.Services
{
    public interface IProfileService
    {
        public Task Create(CreateProfileRequest createProfileRequest);
    }
}
