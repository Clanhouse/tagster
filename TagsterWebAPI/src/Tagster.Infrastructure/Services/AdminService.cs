using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;
using Tagster.Application.Utils;

namespace Tagster.Infrastructure.Services
{
    internal sealed class AdminService : IAdminService
    {
        private readonly ITagsterDbContext _context;

        public AdminService(ITagsterDbContext context)
        {
            _context = context;
        }

        public async Task CreateFakeData(int profilesCount, int maxTagsPerProfile)
        {
            Random rand = new();
            for (int i=0; i<profilesCount; i++) 
            {
                var name = FakeDataUtils.Names[rand.Next(FakeDataUtils.Names.Length)];

                var surname = FakeDataUtils.Surnames[rand.Next(FakeDataUtils.Surnames.Length)];

                var tags = new List<Tag>();

                for (int j = 0; j<rand.Next(maxTagsPerProfile); j++)
                {
                    string tagName = FakeDataUtils.Tags[rand.Next(FakeDataUtils.Tags.Length)];
                    Tag tag = new Tag();
                    tag.TagName = tagName;
                    tags.Add(tag);
                }

                var profile = new Profile
                {
                    Href = Guid.NewGuid().ToString(),
                    LastName = surname,
                    Name = name,
                    ProfileTags = tags
                };

                await _context.Profiles.AddAsync(profile);
            }

            await _context.SaveChangesAsync();
        }
    }
}
