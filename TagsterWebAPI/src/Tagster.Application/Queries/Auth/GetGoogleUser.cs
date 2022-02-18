using Tagster.Application.Dtos;
using Tagster.CQRS.Queries;

namespace Tagster.Application.Queries.Auth;

public class GetGoogleUser : IQuery<GoogleUserDto>
{
    public string IdToken { get; }
    public GetGoogleUser(string idToken) => IdToken = idToken;
}
