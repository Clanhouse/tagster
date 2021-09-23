using Tagster.Auth.Models;

namespace Tagster.Auth.Handlers
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(int userId, string email);
        JsonWebRefreshToken CreateRefreshToken(string accessToken, int userId);
    }
}
