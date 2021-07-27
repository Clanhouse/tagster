using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Infrastructure.Services
{
    internal sealed class TagsService : ITagsService
    {
        private readonly ITagsterDbContext _tagsterDb;

        public TagsService(ITagsterDbContext tagsterDb)
           => _tagsterDb = tagsterDb;

        public async Task<ICollection<Tag>[]> GetList(string name) 
            => await _tagsterDb
                .Profiles
                .Where(profile => profile.Name.Equals(name))
                .Include(profile => profile.ProfileTags)
                .Select(profile => profile.ProfileTags)
                .ToArrayAsync();
        public async Task<ICollection<Tag>> GetAsync()
            => await _tagsterDb
                .Tags
                .Select(tags => tags)
                .ToArrayAsync();

    }
}
