using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Models;

namespace Tagster.Auth.Services
{
    public interface IIdentityService
    {
        //Task<UserDto> GetAsync(Guid id);
        Task<AuthDto> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
        Task SignOutAsync(SignOut command);
    }
}
