using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public class TagsterDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
<<<<<<< HEAD

        public TagsterDbContext(DbContextOptions options) : base(options)
        {
=======
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public TagsterDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Profile>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RefreshToken>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        }
    }
}
