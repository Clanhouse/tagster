using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    public interface ITagsService
    {
        Task<ICollection<Tag>[]> GetList(string profileName);
        Task InstertDataAsync(Profile profile);
    }
}
