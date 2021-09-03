using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public class TagsterDbContext : DbContext, ITagsterDbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

        public TagsterDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<UserCredential>().ToTable("Credentials");
        }
    }
}
