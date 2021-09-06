<<<<<<< HEAD
﻿namespace Tagster.Auth.Exceptions
{
    public class RevokedRefreshTokenException : AuthException
    {
        public override string Code { get; } = "revoked_refresh_token";
=======
﻿using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Auth.Exceptions
{
    public class RevokedRefreshTokenException : DomainException
    {
        public override string Code { get; } = "revoked_refresh_token";
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
>>>>>>> e56f5e008b44f871bf3346eb31d0999174b491f7

        public RevokedRefreshTokenException() : base("Revoked refresh token.")
        {
        }
    }
}
