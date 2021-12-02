using Tagster.Auth.Dtos;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.RefreshTokens;

public class RefreshTokens : ICommand<AuthDto>
{
    public string RefreshToken { get; set; }

}
