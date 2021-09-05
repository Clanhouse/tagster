using System;
using Tagster.Auth.Dtos;

namespace Tagster.Application.Services
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string email);
    }
}
