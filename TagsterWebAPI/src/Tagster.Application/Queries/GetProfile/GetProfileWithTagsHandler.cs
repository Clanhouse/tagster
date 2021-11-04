using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Application.Dtos;
using Tagster.DataAccess.DBContexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tagster.Application.Queries.GetProfile
{
    internal sealed class GetProfileWithTagsHandler : IQueryHandler<GetProfileWithTags, ProfileDto>
    {
        private readonly ITagsService _tagService;
        public GetProfileWithTagsHandler(ITagsService tagService)
        {
            _tagService = tagService;
        }
        private readonly TagsterDbContext _tagsterDb;
        public GetProfileWithTagsHandler(TagsterDbContext tagsterDb)
            => _tagsterDb = tagsterDb;

        public async Task<ProfileDto> Handle(GetProfileWithTags request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Profile profileInfo = _tagsterDb
                .Profiles
                .Where(profile => profile.Href.Equals(request.Href))
                .Include(profile => profile.ProfileTags)
                .Include(profile => profile.Name)
                .Include(profile => profile.LastName)
                .FirstOrDefault();

            ProfileDto profileDto = new();
            profileDto.Href = profileInfo.Href;
            profileDto.Id = profileInfo.Id;
            profileDto.LastName= profileInfo.LastName;
            profileDto.Name = profileInfo.Name;
            profileDto.ProfileTags = profileInfo.ProfileTags;
            
            return await _tagService.GetHref(profileDto);
        }
    }
}
