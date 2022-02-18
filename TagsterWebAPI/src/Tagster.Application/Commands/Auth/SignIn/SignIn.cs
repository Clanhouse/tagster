using Tagster.Auth.Dtos;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.Auth.SignIn;

public class SignIn : ICommand<AuthDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
