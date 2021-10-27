using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Application.Dtos;

namespace Tagster.Application.Queries.GetProfile
{
    internal sealed class GetProfileWithTagsHandler : IQueryHandler<GetProfileWithTags, ProfileDto>
    {
        private readonly ITagsService _tagService;
        public GetProfileWithTagsHandler(ITagsService tagService)
        {
            _tagService = tagService;
        }

        public async Task<ProfileDto> Handle(GetProfileWithTags request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
