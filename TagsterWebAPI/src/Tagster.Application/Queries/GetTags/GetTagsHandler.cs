using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
using Tagster.CQRS.Queries.Handlers;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Queries.GetTags;

internal class GetTagsHandler : IQueryHandler<GetTags, ICollection<TagDto>>
{
    private readonly ITagsRepository _repository;
    public GetTagsHandler(ITagsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<TagDto>> Handle(GetTags request, CancellationToken cancellationToken)
    {
        return (await _repository.GetList(request.ProfileName)).Select(t => new TagDto { Name = t.Name }).ToList();
    }
}
