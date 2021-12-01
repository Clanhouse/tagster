using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.SignOut
{
    public class SignOutHandler : ICommandHandler<SignOut>
    {
        private readonly IIdentityService _identityService;

        public SignOutHandler(IIdentityService identityService) => _identityService = identityService;

        public async Task<Unit> Handle(SignOut request, CancellationToken cancellationToken)
        {
            await _identityService.SignOutAsync(
                           new Auth.Models.SignOut(request.AccessToken, request.RefreshToken), cancellationToken);
            return Unit.Value;
        }
    }
}
