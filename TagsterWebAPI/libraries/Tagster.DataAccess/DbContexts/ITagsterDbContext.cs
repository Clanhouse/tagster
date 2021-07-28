using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public interface ITagsterDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Profile> Profiles { get; set; }
        public Task<int> SaveChangesAsync();
    }
}