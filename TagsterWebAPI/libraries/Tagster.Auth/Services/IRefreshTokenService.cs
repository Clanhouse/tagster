using System.Threading.Tasks;
using Tagster.Auth.Dtos;

namespace Tagster.Auth.Services
{
    public interface IRefreshTokenService
    {
        Task<string> CreateAsync(int userId);
        Task RevokeAsync(string refreshToken);
        Task<AuthDto> UseAsync(string refreshToken);
    }
}
