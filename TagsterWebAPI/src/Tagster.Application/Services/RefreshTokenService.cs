using System;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.DataAccess.DBContexts;

namespace Tagster.Application.Services
{
    internal sealed class RefreshTokenService : IRefreshTokenService
    {
        private readonly TagsterDbContext _tagsterDb;
        //private readonly IRng _rng;

        public RefreshTokenService(TagsterDbContext tagsterDb)
            => _tagsterDb = tagsterDb;

        public async Task<string> CreateAsync(Guid userId)
        {
            //var token = _rng.Generate(30, true);
            //var refreshToken = new RefreshToken(new AggregateId(), userId, token, DateTime.UtcNow, DateTime.UtcNow.AddDays(7));
            //await _refreshTokenRepository.AddAsync(refreshToken);

            //return token;
            throw new NotImplementedException();
        }

        public async Task RevokeAsync(string refreshToken)
        {
            //var token = await _refreshTokenRepository.GetAsync(refreshToken);
            //if (token is null)
            //{
            //    throw new InvalidRefreshTokenException();
            //}

            //token.Revoke(DateTime.UtcNow);
            //await _refreshTokenRepository.UpdateAsync(token);
            throw new NotImplementedException();
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
            //var token = await _refreshTokenRepository.GetAsync(refreshToken);

            //if (token is null)
            //    throw new InvalidRefreshTokenException();

            //if (token.Revoked)
            //    throw new RevokedRefreshTokenException();

            //var user = await _userRepository.GetAsync(token.UserId);
            //if (user is null)
            //    throw new UserNotFoundException(token.UserId);

            //var auth = _jwtProvider.Create(token.UserId, user.Email);
            //await _refreshTokenRepository.UpdateAsync(new RefreshToken(token.Id, token.UserId, token.Token, DateTime.UtcNow, DateTime.UtcNow.AddDays(7)));

            //auth.RefreshToken = refreshToken;

            //return auth;
            throw new NotImplementedException();
        }
    }
}
