using System;
using Tagster.Auth.Models;

namespace Tagster.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(string userId, string email);

        JsonWebRefreshToken CreateRefreshToken(string accessToken, Guid userId);
    }
}