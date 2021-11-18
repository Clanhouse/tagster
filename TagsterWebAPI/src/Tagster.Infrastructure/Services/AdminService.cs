using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;
using Tagster.DataAccess.Models;
using System.Text.Json;
using System.IO;
using Tagster.Application.Factories;
using Tagster.Application.Commands.GenFakeData;
using Tagster.Application.Commands.AddTagsToProfile;

namespace Tagster.Infrastructure.Services
{
    internal sealed class AdminService : IAdminService
    {
        private readonly TagsterDbContext _context;

        public AdminService(TagsterDbContext context) => _context = context;

        public async Task CreateFakeDataAsync(GenFakeData request)
        {
            Random rand = new();

            if(!File.Exists(Path.Combine(AppContext.BaseDirectory, "FakeData.json")))
                throw new ArgumentException("File FakeData.json does not exist");

            string json = new StreamReader(Path.Combine(AppContext.BaseDirectory, "FakeData.json")).ReadToEnd();

            FakeData fakeData = JsonSerializer.Deserialize<FakeData>(json);
            for (int i = 0; i < request.ProfilesCount; i++)
            {
                string name = fakeData.Names[rand.Next(fakeData.Names.Length)];

                string surname = fakeData.Surnames[rand.Next(fakeData.Surnames.Length)];

                string href = fakeData.Hrefs[rand.Next(fakeData.Hrefs.Length)];

                ICollection<Tag> tags = TagFactory.Create(maxTagsPerProfile, fakeData);

                Profile profile = ProfileFactory.Create(new AddTagsToProfile()
                {
                    Surname = surname,
                    Name = name,
                    Tags = tags,
                    Href = href
                });

                await _context.Profiles.AddAsync(profile);
            }

            await _context.SaveChangesAsync();
        }
    }
}
