using System.Threading;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.Auth.External;

public class ExternalAuthHandler : ICommandHandler<ExternalAuth, AuthDto>
{
    private readonly IIdentityService _identityService;

    public ExternalAuthHandler(IIdentityService identityService) => _identityService = identityService;

    public Task<AuthDto> Handle(ExternalAuth request, CancellationToken cancellationToken)
        => _identityService.ExternalAuth(request.Email, cancellationToken);
}
