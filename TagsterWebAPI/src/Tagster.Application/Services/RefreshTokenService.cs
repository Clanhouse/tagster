using System;
<<<<<<< HEAD
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.DataAccess.DBContexts;
=======
using System.Linq;
using System.Threading.Tasks;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Tagster.Application.Exceptions;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7

namespace Tagster.Application.Services
{
    internal sealed class RefreshTokenService : IRefreshTokenService
    {
        private readonly TagsterDbContext _tagsterDb;
<<<<<<< HEAD
        //private readonly IRng _rng;

        public RefreshTokenService(TagsterDbContext tagsterDb)
        {
            _tagsterDb = tagsterDb;
        }

        public async Task<string> CreateAsync(Guid userId)
        {
            //var token = _rng.Generate(30, true);
            //var refreshToken = new RefreshToken(new AggregateId(), userId, token, DateTime.UtcNow, DateTime.UtcNow.AddDays(7));
            //await _refreshTokenRepository.AddAsync(refreshToken);

            //return token;
            throw new NotImplementedException();
=======
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
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        }

        public async Task RevokeAsync(string refreshToken)
        {
<<<<<<< HEAD
            //var token = await _refreshTokenRepository.GetAsync(refreshToken);
            //if (token is null)
            //{
            //    throw new InvalidRefreshTokenException();
            //}

            //token.Revoke(DateTime.UtcNow);
            //await _refreshTokenRepository.UpdateAsync(token);
            throw new NotImplementedException();
=======
            var token = _tagsterDb.RefreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken));
            if (token is null)
                throw new InvalidRefreshTokenException();

            _tagsterDb.RefreshTokens.Update(
                new RefreshToken(token.Token, token.CreatedAt, token.UserId, DateTime.UtcNow));
            await _tagsterDb.SaveChangesAsync();
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
<<<<<<< HEAD
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
=======
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
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        }
    }
}
