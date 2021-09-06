using System;
using Tagster.Auth.Models;

namespace Tagster.Auth.Handlers
{
    public interface IJwtHandler
    {
<<<<<<< HEAD
        JsonWebToken CreateToken(string userId, string email);

        JsonWebRefreshToken CreateRefreshToken(string accessToken, Guid userId);
=======
        JsonWebToken CreateToken(int userId, string email);

        JsonWebRefreshToken CreateRefreshToken(string accessToken, int userId);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
    }
}