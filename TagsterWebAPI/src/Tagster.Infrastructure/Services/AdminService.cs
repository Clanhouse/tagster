using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Tagster.Application.Commands.AddTagsToProfile;
using Tagster.Application.Commands.GenFakeData;
using Tagster.Application.Factories;
using Tagster.Application.Services;
using Tagster.DataAccess.Models;
using Tagster.Infrastructure.EF;

namespace Tagster.Infrastructure.Services;

internal sealed class AdminService : IAdminService
{
    private readonly TagsterDbContext _context;

    public AdminService(TagsterDbContext context) => _context = context;

    public async Task CreateFakeDataAsync(GenFakeData request)
    {
        Random rand = new();

        if (!File.Exists(Path.Combine(AppContext.BaseDirectory, "FakeData.json")))
            throw new ArgumentException("File FakeData.json does not exist");

        var json = new StreamReader(Path.Combine(AppContext.BaseDirectory, "FakeData.json")).ReadToEnd();

        var fakeData = JsonSerializer.Deserialize<FakeData>(json);
        for (int i = 0; i < request.ProfilesCount; i++)
        {
            var name = fakeData.Names[rand.Next(fakeData.Names.Length)];
            var surname = fakeData.Surnames[rand.Next(fakeData.Surnames.Length)];

            var profile = ProfileFactory.Create(new AddTagsToProfile()
            {
                Surname = surname,
                Name = name,
                Tags = TagFactory.Create(request.MaxTagsPerProfile, fakeData),
                Href = $"{name}-{surname}"
            });

            await _context.Profiles.AddAsync(profile);
        }

        await _context.SaveChangesAsync();
    }
}
