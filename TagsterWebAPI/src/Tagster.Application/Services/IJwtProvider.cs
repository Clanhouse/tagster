using System;
using Tagster.Auth.Dtos;

namespace Tagster.Application.Services
{
    public interface IJwtProvider
    {
<<<<<<< HEAD
        AuthDto Create(Guid userId, string email);
=======
        AuthDto Create(int userId, string email);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
    }
}
