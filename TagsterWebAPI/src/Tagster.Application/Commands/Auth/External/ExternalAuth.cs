using System;
using Tagster.Application.Exceptions;
using Tagster.Auth.Dtos;
using Tagster.CQRS.Commands;

namespace Tagster.Application.Commands.Auth.External;

public class ExternalAuth : ICommand<AuthDto>
{
    public string Email { get; }
    public ExternalAuth(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ExternalAuthEmptyEmailException();
        Email = email;
    }
}
