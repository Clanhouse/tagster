using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Tagster.Application.Dtos;
using Tagster.Auth.Options;
using Tagster.CQRS.Queries.Handlers;

namespace Tagster.Application.Queries.Auth;

public class GetGoogleUserHandler : IQueryHandler<GetGoogleUser, GoogleUserDto>
{
    private readonly string _audience;

    public GetGoogleUserHandler(IOptions<ExternalAuthOptions> options)
    {
        _audience = options.Value.Google.Audience;
    }
    
    public async Task<GoogleUserDto> Handle(GetGoogleUser request, CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new List<string> { _audience }
        };

        GoogleJsonWebSignature.Payload payload  = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
        return new GoogleUserDto(payload.Email);
    }
}
