using System.Threading;
using System.Threading.Tasks;
using Tagster.Domain.Entities;

namespace Tagster.Domain.Repositories;

public interface IUserRepository
{
    ValueTask<User> FindAsync(int id, CancellationToken cancellationToken = default);
    ValueTask<User> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
    ValueTask AddAsync(User user, CancellationToken cancellationToken = default);
}
