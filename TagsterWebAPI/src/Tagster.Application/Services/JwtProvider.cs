using Tagster.Auth.Dtos;
using Tagster.Auth.Handlers;

namespace Tagster.Application.Services;

public class JwtProvider : IJwtProvider
{
    private readonly IJwtHandler _jwtHandler;

    public JwtProvider(IJwtHandler jwtHandler)
        => _jwtHandler = jwtHandler;

    public AuthDto Create(int userId, string email)
    {
        var jwt = _jwtHandler.CreateToken(userId, email);

        return new AuthDto
        {
            Id = userId,
            AccessToken = jwt.AccessToken,
            RefreshToken = jwt.RefreshToken,
        };
    }
}
