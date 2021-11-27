using System.Collections.Generic;
using Tagster.CQRS.Queries.Handlers;
using System.Threading.Tasks;
using Tagster.Application.Dtos;
using System.Threading;
using Tagster.Domain.Repositories;
using System.Linq;

namespace Tagster.Application.Queries.GetTags
{
    internal class GetTagsHandler : IQueryHandler<GetTags, ICollection<TagDto>>
    {
        private readonly ITagsRepository _repository;
        public GetTagsHandler(ITagsRepository repository) 
            => _repository = repository;

        public async Task<ICollection<TagDto>> Handle(GetTags request, CancellationToken cancellationToken) 
            => (await _repository.GetList(request.ProfileName)).Select(t => new TagDto { Name = t.Name }).ToList();
    }
}
