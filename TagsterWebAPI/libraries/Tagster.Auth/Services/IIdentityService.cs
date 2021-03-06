using System.Threading;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Models;

namespace Tagster.Auth.Services;

public interface IIdentityService
{
    Task<AuthDto> SignInAsync(SignIn command, CancellationToken cancellationToken);
    Task SignUpAsync(SignUp command, CancellationToken cancellationToken);
    Task SignOutAsync(SignOut command, CancellationToken cancellationToken);
    Task<AuthDto> ExternalAuth(string email, CancellationToken cancellationToken);

}
