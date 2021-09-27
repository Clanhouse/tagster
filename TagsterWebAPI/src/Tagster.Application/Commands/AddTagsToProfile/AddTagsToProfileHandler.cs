using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Application.Services;
using Tagster.CQRS.Commands.Handlers;
using Tagster.DataAccess.Entities;
using Tagster.Application.Factories;

namespace Tagster.Application.Commands.AddTagsToProfile
{
    public sealed class AddTagsToProfileHandler : ICommandHandler<AddTagsToProfile>
    {
        private readonly ITagsService _tagService;

        public AddTagsToProfileHandler(ITagsService tagService)
        {
            _tagService = tagService;
        }

        public async Task<Unit> Handle(AddTagsToProfile request, CancellationToken cancellationToken)
        {
            Profile profile = ProfileFactory.Create(request);

            await _tagService.InstertDataAsync(profile);
            return Unit.Value;
        }
    }
}
