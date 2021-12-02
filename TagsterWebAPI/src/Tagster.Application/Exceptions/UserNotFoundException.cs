using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class UserNotFoundException : AppException
{
    public override string Code { get; } = "user_not_found";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
    public int UserId { get; }

    public UserNotFoundException(int userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}
