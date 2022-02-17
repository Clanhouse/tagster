using System.Collections.Generic;

namespace Tagster.Domain.Authorization;

public static class Policy
{
    public const string User = "User";
    public static Dictionary<string, string[]> Policies { get; }  = new()
    {
        { User, new[] { Role.User, Role.VIP } }
    };
}
