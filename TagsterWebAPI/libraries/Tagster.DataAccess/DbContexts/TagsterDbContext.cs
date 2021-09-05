using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public class TagsterDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public TagsterDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
