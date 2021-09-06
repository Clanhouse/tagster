using System;
using System.Net;
using Tagster.Exception.Models;

namespace Epilepsy_Health_App.Services.Identity.Application.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public override string Code { get; } = "user_not_found";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
<<<<<<< HEAD
        public Guid UserId { get; }

        public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
=======
        public int UserId { get; }

        public UserNotFoundException(int userId) : base($"User with ID: '{userId}' was not found.")
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7
        {
            UserId = userId;
        }
    }
}
