using System.Threading.Tasks;
using Tagster.Domain.Entities;

namespace Tagster.Domain.Repositories
{
    public interface IRefreshTokenRepository
    {
        ValueTask<RefreshToken> Get(string refreshToken);
        ValueTask Add(RefreshToken refreshToken);
        ValueTask Update(RefreshToken refreshToken);
    }
}
