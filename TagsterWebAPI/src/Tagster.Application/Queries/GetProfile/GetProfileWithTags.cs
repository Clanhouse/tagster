using Tagster.Application.Dtos;
using Tagster.CQRS.Queries;

namespace Tagster.Application.Queries.GetProfile
{
    public class GetProfileWithTags :IQuery<ProfileDto>
    {
        public string Href { get; set; }
    }
}
