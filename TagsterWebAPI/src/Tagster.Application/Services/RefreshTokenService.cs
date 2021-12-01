using System;
using System.Threading.Tasks;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Tagster.Application.Exceptions;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Services
{
    internal sealed class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRng _rng;
        private readonly IJwtProvider _jwtProvider;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository,
            IRng rng, IJwtProvider jwtProvider)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _rng = rng;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> CreateAsync(int userId)
        {
            var token = _rng.Generate(removeSpecialChars: true);
            await _refreshTokenRepository.Add(new RefreshToken(token, DateTime.UtcNow, userId, DateTime.UtcNow.AddDays(7)));


            return token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.Get(refreshToken);
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            await _refreshTokenRepository.Update(new(token.Token, token.CreatedAt, token.UserId, DateTime.UtcNow));
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.Get(refreshToken);

            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            if (DateTime.Compare(DateTime.Now, token.RevokedAt.Value) > 0)
            {
                throw new RevokedRefreshTokenException();
            }

            var user = await _userRepository.FindAsync(token.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(token.UserId);
            }

            var auth = _jwtProvider.Create(token.UserId, user.Email);
            await _refreshTokenRepository.Update(new(token.Id, token.Token,
                DateTime.UtcNow, token.UserId, DateTime.UtcNow.AddDays(7)));

            auth.RefreshToken = refreshToken;

            return auth;
        }
    }
}
