using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.SignUp
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService) 
            => _identityService = identityService;

        public async Task<Unit> Handle(SignUp request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            await _identityService.SignUpAsync(new Auth.Models.SignUp(request.Password, request.Email), cancellationToken);
=======
            await _identityService.SignUpAsync(new Auth.Models.SignUp(request.Email, request.Password), cancellationToken);
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
            return Unit.Value;
        }
    }
}
