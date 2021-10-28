using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
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

        public async Task InstertDataAsync(Profile profile)
        {
            await _tagsterDb.Profiles.AddAsync(profile);
            await _tagsterDb.SaveChangesAsync();
        }

        /*public async Task GetHref(string Href)
            => await _tagsterDb
                .Profiles
                .Where(profile => profile.Href.Equals(Href))
                .Include(profile => profile.ProfileTags)
                .Include(profile => profile.Name)
                .Include(profile => profile.LastName)
                .Select(profile => profile.ProfileTags)
                .ToArrayAsync();*/

        public async Task<ProfileDto> GetHref(string Href)
        {
            //string href = Href.Href;
            return await _tagsterDb
              .Profiles
              .Where(profile => profile.Href.Equals(Href))
              .Include(profile => profile.ProfileTags)
              .Include(profile => profile.Name)
              .Include(profile => profile.LastName)
              .Select(profile => profile.Name)
              .ToArrayAsync();
        }
    }
}
