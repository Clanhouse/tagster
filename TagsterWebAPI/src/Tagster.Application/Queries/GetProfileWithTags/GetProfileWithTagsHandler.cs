using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
using Tagster.Application.Exceptions;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Queries.GetProfileWithTags;

public sealed class GetProfileWithTagsHandler : IQueryHandler<GetProfileWithTags, ProfileDto>
{
    private readonly ITagsRepository _repository;
    public GetProfileWithTagsHandler(ITagsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProfileDto> Handle(GetProfileWithTags request, CancellationToken cancellationToken)
    {
        var profile = await _repository.GetProfileWithTags(request.Href);
        if(profile == null) throw new ProfileNotFoundException(request.Href);
        return Map(profile);
    }

    private static ProfileDto Map(Profile profile)
    {
        ProfileDto profileDto = new() { 
            Id = profile.Id,
            Href = profile.Href,
            Name = profile.Name,
            LastName = profile.LastName,
            Tags = profile.Tags.Select(pt => new TagDto { Name = pt.Name }).ToList()
        };

        return profileDto;
    }
}
