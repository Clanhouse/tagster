using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Infrastructure.Services
{
    internal sealed class TagsService : ITagsService
    {
        private readonly TagsterDbContext _tagsterDb;

        public TagsService(TagsterDbContext tagsterDb)
           => _tagsterDb = tagsterDb;

        public async Task<ICollection<Tag>[]> GetList(string profileName)
            => await _tagsterDb
                .Profiles
                .Where(profile => profile.Name.Equals(profileName))
                .Include(profile => profile.ProfileTags)
                .Select(profile => profile.ProfileTags)
                .ToArrayAsync();

    }
}
