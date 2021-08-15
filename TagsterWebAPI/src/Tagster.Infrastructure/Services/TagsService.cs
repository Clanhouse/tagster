using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Infrastructure.Services
{
    internal sealed class TagsService : ITagService
    {
        private readonly ITagsterDbContext _tagsterDb;

        public TagsService(ITagsterDbContext tagsterDb)
           => _tagsterDb = tagsterDb;

        public async Task<ICollection<Tag>[]> GetList(string href)
            => await _tagsterDb
                .Profiles
                .Where(profile => profile.Href.Equals(href))
                .Include(profile => profile.ProfileTags)
                .Select(profile => profile.ProfileTags)
                .ToArrayAsync();

        public async Task<ICollection<Tag>[]> PutList(string href, ICollection<Tag> tags)
        {
            _tagsterDb.Profiles.Where(profile => profile.Href.Equals(href)).ToList().ForEach(profile => profile.ProfileTags = tags);
            await _tagsterDb.SaveChangesAsync();
            return await GetList(href);
        }
    }
}
