using Microsoft.EntityFrameworkCore;
using Tagster.Domain.Models;

namespace Tagster.Application.Interfaces
{
    public interface ITagsterDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Profile> Profiles { get; set; }
    }
}