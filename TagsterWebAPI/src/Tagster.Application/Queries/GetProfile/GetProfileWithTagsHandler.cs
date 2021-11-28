using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Queries.GetProfile
{
    internal sealed class GetProfileWithTagsHandler : IQueryHandler<GetProfileWithTags, ProfileDto>
    {
        private readonly ITagsRepository _repository;
        public GetProfileWithTagsHandler(ITagsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProfileDto> Handle(GetProfileWithTags request, CancellationToken cancellationToken)
        {
            return Map(await _repository.GetProfileWithTags(request.Href));
        }

        private static ProfileDto Map(Profile profile)
        {
            if (profile == null)
            {
                return null;
            }

            ProfileDto profileDto = new();

            profileDto.Href = profile.Href;
            profileDto.Id = profile.Id;
            profileDto.Name = profile.Name;
            profileDto.LastName = profile.LastName;
            profileDto.Tags = profile.Tags.Select(pt => new TagDto { Name = pt.Name }).ToList();

            return profileDto;
        }
    }
}
