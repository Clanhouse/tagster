using Tagster.Auth.Models;

namespace Tagster.Auth.Handlers;

public interface IJwtHandler
{
    JsonWebToken CreateToken(int userId, string email, string role);
    JsonWebRefreshToken CreateRefreshToken(string accessToken, int userId);
}
