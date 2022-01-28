using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.Auth.SignOut;

public class SignOut : ICommand
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
