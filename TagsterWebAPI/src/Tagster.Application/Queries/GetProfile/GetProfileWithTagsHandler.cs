using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Application.Dtos;
using Tagster.DataAccess.Entities;
using Tagster.DataAccess.DBContexts;

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
            return Map(await _tagService.GetProfileWithTags(request.Href));
        }

        private static ProfileDto Map(Profile profile)
        {
            ProfileDto profileDto = new();

            profileDto.Href = profile.Href;
            profileDto.Id = profile.Id;
            profileDto.Name = profile.Name;
            profileDto.LastName = profile.LastName;
            profileDto.ProfileTags = profile.ProfileTags;

            return profileDto;
        }
    }
}
