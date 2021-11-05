using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    public interface ITagsService
    {
        Task<ICollection<Tag>[]> GetList(string profileName);
        Task<Profile> GetProfileWithTags(string href);
        Task InstertDataAsync(Profile profile);
    }
}
