using System;

namespace Tagster.DataAccess.Entities
{
    public record User(Guid Id, string Email, string Password, DateTime CreatedAt);
}
