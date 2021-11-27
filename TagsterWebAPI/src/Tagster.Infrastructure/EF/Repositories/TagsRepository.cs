using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Infrastructure.EF.Repositories
{
    internal sealed class TagsRepository : ITagsRepository
    {
        private readonly TagsterDbContext _tagsterDb;
        private readonly DbSet<Profile> _profiles;
        private readonly DbSet<Tag> _tags;

        public TagsRepository(TagsterDbContext tagsterDb)
        {
            _tagsterDb = tagsterDb;
            _profiles = tagsterDb.Profiles;
            _tags = tagsterDb.Tags;
        }

        public async Task<ICollection<Tag>> GetList(string profileName)
            => await _tags
            .Where(t => t.ProfileId.Equals(_profiles.FirstOrDefault(p => p.Name.Equals(profileName)).Id))
            .ToListAsync();
        
        public async Task InstertDataAsync(Profile profile)
        {
            await _profiles.AddAsync(profile);
            await _tagsterDb.SaveChangesAsync();
        }

        public async Task<Profile> GetProfileWithTags(string href)
        {
            Profile profileInfo = await _profiles
                .Where(profile => profile.Href.Equals(href))
                .Include(profile => profile.Tags)
                .SingleOrDefaultAsync();

            return profileInfo;
        }
    }
}
