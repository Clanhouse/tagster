using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Application.Factories;
using Tagster.CQRS.Commands.Handlers;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Commands.AddTagsToProfile;

public sealed class AddTagsToProfileHandler : ICommandHandler<AddTagsToProfile>
{
    private readonly ITagsRepository _repository;

    public AddTagsToProfileHandler(ITagsRepository repository)
        => _repository = repository;

    public async Task<Unit> Handle(AddTagsToProfile request, CancellationToken cancellationToken)
    {
        await _repository.InsertDataAsync(ProfileFactory.Create(request));
        return Unit.Value;
    }
}
