using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    public interface ITagsService
    {
        Task<ICollection<Tag>[]> GetList(string profileName);
        public Task InstertDataAsync(string surname, string name, ICollection<Tag> tags);
    }
}
