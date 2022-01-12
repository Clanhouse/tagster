using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Application.Exceptions;
using Tagster.CQRS.Commands.Handlers;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Commands.ChangeUserRole;

internal sealed class ChangeUserRoleHandler : ICommandHandler<ChangeUserRole>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserRoleHandler(IUserRepository userRepository) 
        => _userRepository = userRepository;

    public async Task<Unit> Handle(ChangeUserRole request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(request.UserId, cancellationToken);
        if (user == null)
            throw new UserNotFoundException(request.UserId);

        user.ChangeRole(request.Role);

        await _userRepository.UpdateAsync(user, cancellationToken);

        return Unit.Value;
    }
}
