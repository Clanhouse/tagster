using System.Threading;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.Auth.SignIn;

public class SignInHandler : ICommandHandler<SignIn, AuthDto>
{
    private readonly IIdentityService _identityService;

    public SignInHandler(IIdentityService identityService)
        => _identityService = identityService;

    public Task<AuthDto> Handle(SignIn request, CancellationToken cancellationToken)
        => _identityService.SignInAsync(new Tagster.Auth.Models.SignIn(request.Email, request.Password), cancellationToken);
}
