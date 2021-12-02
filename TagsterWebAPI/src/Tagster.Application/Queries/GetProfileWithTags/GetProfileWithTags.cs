using Tagster.Application.Dtos;
using Tagster.CQRS.Queries;

namespace Tagster.Application.Queries.GetProfileWithTags
{
    public class GetProfileWithTags : IQuery<ProfileDto>
    {
        public string Href { get; set; }
    }
}
