using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Tagster.DataAccess.Entities;

namespace Tagster.DataAccess.DBContexts
{
    public interface ITagsterDbContext
    {
        DbSet<Tag> Tags { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<UserCredential> UserCredentials { get; set; }
    }
}