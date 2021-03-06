using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.Auth.SignUp;

public sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IIdentityService _identityService;

    public SignUpHandler(IIdentityService identityService)
        => _identityService = identityService;

    public async Task<Unit> Handle(SignUp request, CancellationToken cancellationToken)
    {
        await _identityService.SignUpAsync(new Tagster.Auth.Models.SignUp(request.Email, request.Password), cancellationToken);
        return Unit.Value;
    }
}
