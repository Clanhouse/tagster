using Microsoft.AspNetCore.Mvc;

namespace Tagster.Infrastructure.Services;

public interface ICookieFactory
{
    void SetResponseRefreshTokenCookie(ControllerBase controllerBase, string token);
    string GetRefreshTokenFromCookie(ControllerBase controllerBase);
}
