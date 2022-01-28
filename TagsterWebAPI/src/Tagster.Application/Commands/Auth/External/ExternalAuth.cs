using System;
using Tagster.Auth.Dtos;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.Auth.External;

public class ExternalAuth : ICommand<AuthDto>
{
    public string Email { get; }
    public ExternalAuth(string email)
    {
        ArgumentNullException.ThrowIfNull(email);
        Email = email;
    }
}
