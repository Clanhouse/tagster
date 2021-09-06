using System;
using Tagster.Auth.Dtos;
using Tagster.Auth.Handlers;

namespace Tagster.Application.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtHandler _jwtHandler;

        public JwtProvider(IJwtHandler jwtHandler) 
            => _jwtHandler = jwtHandler;

<<<<<<< HEAD
        public AuthDto Create(Guid userId, string email)
        {
            var jwt = _jwtHandler.CreateToken(userId.ToString(), email);
=======
        public AuthDto Create(int userId, string email)
        {
            var jwt = _jwtHandler.CreateToken(userId, email);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7

            return new AuthDto
            {
                Id = userId,
                AccessToken = jwt.AccessToken,
                RefreshToken = jwt.RefreshToken,
            };
        }
    }
}
