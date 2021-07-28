using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public class TagsterDbContext : DbContext, ITagsterDbContext
    {
        public TagsterDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
