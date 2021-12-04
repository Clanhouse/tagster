using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class ProfileNotFoundException : AppException
{
    public override string Code => "profile_not_found";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public ProfileNotFoundException(string href) : base($"Profile with HREF: '{href}' was not found.")
    {
    }
}
