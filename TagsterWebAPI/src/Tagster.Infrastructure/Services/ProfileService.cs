using System.Threading.Tasks;
using Tagster.Application.Dtos.Requests;
using Tagster.Application.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Infrastructure.Services
{
    internal sealed class ProfileService : IProfileService
    {
        private readonly ITagsterDbContext _context;

        public ProfileService(ITagsterDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateProfileRequest createProfileRequest)
        {
            var profile = new Profile
            {
                Href = createProfileRequest.Href,
                LastName = createProfileRequest.Lastname,
                Name = createProfileRequest.Name
            };

            await _context.Profiles.AddAsync(profile);
             await _context.SaveChangesAsync();
        }
    }
}
