using System;
using System.Linq;
using System.Threading.Tasks;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Tagster.Application.Exceptions;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    internal sealed class RefreshTokenService : IRefreshTokenService
    {
        private readonly TagsterDbContext _tagsterDb;
        private readonly IRng _rng;
        private readonly IJwtProvider _jwtProvider;

        public RefreshTokenService(TagsterDbContext tagsterDb, IRng rng, IJwtProvider jwtProvider)
        {
            _tagsterDb = tagsterDb;
            _rng = rng;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> CreateAsync(int userId)
        {
            var token = _rng.Generate(removeSpecialChars: true);
            await _tagsterDb.RefreshTokens.AddAsync(
                new RefreshToken(token, DateTime.UtcNow, userId, DateTime.UtcNow.AddDays(7)));
            await _tagsterDb.SaveChangesAsync();

            return token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = _tagsterDb.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));
            if (token is null)
                throw new InvalidRefreshTokenException();

            _tagsterDb.RefreshTokens.Update(
                new RefreshToken(token.Token, token.CreatedAt, token.UserId, DateTime.UtcNow));
            await _tagsterDb.SaveChangesAsync();
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
            var token = _tagsterDb.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));

            if (token is null)
                throw new InvalidRefreshTokenException();

            if (DateTime.Compare(DateTime.Now, token.RevokedAt.Value) > 0)
                throw new RevokedRefreshTokenException();

            var user = await _tagsterDb.Users.FindAsync(token.UserId);
            if (user is null)
                throw new UserNotFoundException(token.UserId);

            var auth = _jwtProvider.Create(token.UserId, user.Email);
            _tagsterDb.RefreshTokens.Update(
               new RefreshToken(token.Id, token.Token, DateTime.UtcNow, token.UserId, DateTime.UtcNow.AddDays(7)));
            await _tagsterDb.SaveChangesAsync();

            auth.RefreshToken = refreshToken;

            return auth;
        }
    }
}
