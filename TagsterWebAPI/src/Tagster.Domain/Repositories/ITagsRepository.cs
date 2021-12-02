using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Domain.Entities;

namespace Tagster.Domain.Repositories;

public interface ITagsRepository
{
    Task<ICollection<Tag>> GetList(string profileName);
    Task<Profile> GetProfileWithTags(string href);
    Task InsertDataAsync(Profile profile);
}
