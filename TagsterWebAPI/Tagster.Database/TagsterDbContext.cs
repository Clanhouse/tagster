using Microsoft.EntityFrameworkCore;

namespace Tagster.Database
{
    public class TagsterDbContext : DbContext
    {
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }


        public TagsterDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
