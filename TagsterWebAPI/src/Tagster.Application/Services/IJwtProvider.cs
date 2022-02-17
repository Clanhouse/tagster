using Tagster.Auth.Dtos;

namespace Tagster.Application.Services;

public interface IJwtProvider
{
    AuthDto Create(int userId, string email, string role);
}
