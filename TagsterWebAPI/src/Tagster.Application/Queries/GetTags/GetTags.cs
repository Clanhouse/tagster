using System.Collections.Generic;
using Tagster.Application.Dtos;
using Tagster.CQRS.Queries;

namespace Tagster.Application.Queries.GetTags
{
    public class GetTags : IQuery<ICollection<TagDto>>
    {
        public string ProfileName { get; set; }
    }
}
