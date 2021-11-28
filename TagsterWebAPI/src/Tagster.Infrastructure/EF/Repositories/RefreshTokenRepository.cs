using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Infrastructure.EF.Repositories
{
    internal class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly TagsterDbContext _tagsterDb;
        private readonly DbSet<RefreshToken> _refreshTokens;

        public RefreshTokenRepository(TagsterDbContext tagsterDb)
        {
            _tagsterDb = tagsterDb;
            _refreshTokens = tagsterDb.RefreshTokens;
        }


        public async ValueTask Add(RefreshToken refreshToken)
        {
            await _refreshTokens.AddAsync(refreshToken);
            await _tagsterDb.SaveChangesAsync();
        }

        public ValueTask<RefreshToken> Get(string refreshToken)
            => new(_refreshTokens.FirstOrDefault(x => x.Token.Equals(refreshToken)));

        public async ValueTask Update(RefreshToken refreshToken)
        {
            _refreshTokens.Update(refreshToken);
            await _tagsterDb.SaveChangesAsync();
        }
    }
}
