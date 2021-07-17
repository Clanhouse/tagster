using Microsoft.EntityFrameworkCore;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Interfaces
{
    public interface ITagsterDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Profile> Profiles { get; set; }
    }
}