using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tagster.Infrastructure.Services
{
    internal sealed class CookieFactory : ICookieFactory
    {
        public void SetResponseRefreshTokenCookie(ControllerBase controllerBase, string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            controllerBase.Response.Cookies.Append("RefreshToken", token, cookieOptions);
        }

        public string GetRefreshTokenFromCookie(ControllerBase controllerBase) => controllerBase.Request.Cookies["RefreshToken"];
    }
}
