using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public interface ITagsterDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<User> Users { get; set; }
    }
}