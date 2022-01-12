using System;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Auth.Dtos;
using Tagster.Auth.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.RefreshTokens;

internal sealed class RefreshTokensHandler : ICommandHandler<RefreshTokens, AuthDto>
{
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshTokensHandler(IRefreshTokenService refreshTokenService) 
        => _refreshTokenService = refreshTokenService;

    public Task<AuthDto> Handle(RefreshTokens request, CancellationToken cancellationToken) 
        => _refreshTokenService.UseAsync(request.RefreshToken);
}
