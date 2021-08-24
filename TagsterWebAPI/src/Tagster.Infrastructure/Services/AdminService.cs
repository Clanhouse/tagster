using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;
using Tagster.Application.Utils;
using System.Text.Json;
using System.IO;

namespace Tagster.Infrastructure.Services
{
    internal sealed class AdminService : IAdminService
    {
        private readonly TagsterDbContext _context;

        public AdminService(TagsterDbContext context)
        {
            _context = context;
        }

        public async Task CreateFakeData(int profilesCount, int maxTagsPerProfile)
        {
            Random rand = new();

            using StreamReader r = new(Path.Combine(AppContext.BaseDirectory, "FakeData.json"));
            string json = r.ReadToEnd();

            FakeData fakeData = JsonSerializer.Deserialize<FakeData>(json); //parse to factories (fakeData)
            for (int i = 0; i < profilesCount; i++) //move contents to factories
            {
                var name = fakeData.Names[rand.Next(fakeData.Names.Length)];

                var surname = fakeData.Surnames[rand.Next(fakeData.Surnames.Length)];

                var tags = new List<Tag>();

                for (int j = 0; j < rand.Next(maxTagsPerProfile); j++)
                {
                    string tagName = fakeData.Tags[rand.Next(fakeData.Tags.Length)];
                    Tag tag = new Tag();
                    tag.TagName = tagName;
                    tags.Add(tag);
                }

                var profile = new Profile
                {
                    Id = i,
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
