using Microsoft.EntityFrameworkCore;
using Tagster.Application.Interfaces;
using Tagster.Domain.Models;

namespace Tagster.DataAccessLibrary
{
    public class TagsterDbContext : DbContext, ITagsterDbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public TagsterDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
