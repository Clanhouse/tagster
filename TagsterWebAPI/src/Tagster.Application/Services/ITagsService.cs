using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    public interface ITagService
    {
        Task<ICollection<Tag>[]> GetList(string name);
    }
}
