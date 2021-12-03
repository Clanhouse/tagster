using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Infrastructure.EF.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly TagsterDbContext _tagsterDb;
    private readonly DbSet<User> _users;

    public UserRepository(TagsterDbContext tagsterDb)
    {
        _tagsterDb = tagsterDb;
        _users = tagsterDb.Users;
    }

    public async ValueTask AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _users.AddAsync(user, cancellationToken);
        await _tagsterDb.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<User> FindAsync(int id, CancellationToken cancellationToken = default)
        => await _users.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

    public ValueTask<User> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        => new(_users.FirstOrDefault(x => x.Email == email));
}
