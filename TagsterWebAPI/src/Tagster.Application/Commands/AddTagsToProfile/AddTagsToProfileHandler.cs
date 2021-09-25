using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Application.Services;
using Tagster.CQRS.Commands.Handlers;
using Tagster.DataAccess.Entities;
using Tagster.DataAccess.Factories;

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
            ProfileFactory.Create(request.Surname, request.Name, request.Tag);

            await _tagService.InstertDataAsync(request.Name,"", new List<Tag>());
            return Unit.Value;
        }
    }
}
