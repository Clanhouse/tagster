using System;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;

namespace Tagster.Auth.Services
{
    public interface IRefreshTokenService
    {
<<<<<<< HEAD
        Task<string> CreateAsync(Guid userId);
=======
        Task<string> CreateAsync(int userId);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        Task RevokeAsync(string refreshToken);
        Task<AuthDto> UseAsync(string refreshToken);
    }
}
