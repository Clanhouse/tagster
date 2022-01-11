using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tagster.Application.Commands.RefreshTokens;
using Tagster.Application.Commands.SignIn;
using Tagster.Application.Commands.SignOut;
using Tagster.Application.Commands.SignUp;
using Tagster.Auth.Dtos;
using Tagster.Infrastructure.Services;

namespace TagsterWebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICookieFactory _cookieFactory;

    public AuthController(IMediator mediator, ICookieFactory cookieFactory)
    {
        _mediator = mediator;
        _cookieFactory = cookieFactory;
    }

    /// <summary>
    /// Sign up user
    /// </summary>
    /// <param name="command">Request body which user would be sign up</param>
    /// <param name="cancellationToken"></param>
    /// <returns>status code 201 created</returns>
    [HttpPost("sign-up")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody] SignUp command, CancellationToken cancellationToken)
    {
        if (!command.Password.Equals(command.ConfirmPassword))
        {
            return BadRequest("Passwords do not match!");
        }

        await _mediator.Send(command, cancellationToken);
        return Accepted();
    }

    /// <summary>
    /// Sign in user 
    /// </summary>
    /// <param name="command">Request body which user would be sign in</param>
    /// <param name="cancellationToken"></param>
    /// <returns>AuthDto</returns>
    [HttpPost("sign-in")]
    [ProducesResponseType(typeof(AuthDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> SignIn([FromBody] SignIn command, CancellationToken cancellationToken)
    {
        var token = await _mediator.Send(command, cancellationToken);
        _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
        return Ok(token);
    }

    /// <summary>
    /// Sign out user and revoke access and refresh token
    /// </summary>
    /// <param name="command">Request body which user would be sign out</param>
    /// <param name="cancellationToken"></param>
    /// <returns>status code 202</returns>
    [HttpPost("sign-out")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize()]
    public async Task<IActionResult> SignOut([FromBody] SignOut command, CancellationToken cancellationToken)
    {
        command.RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this);
        await _mediator.Send(command, cancellationToken);
        return Accepted();
    }


    /// <summary>
    /// Refresh token after expire access token
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>AuthDto</returns>
    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(AuthDto), StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Refresh_Token(CancellationToken cancellationToken)
    {
        var command = new RefreshTokens { RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this) };

        var token = await _mediator.Send(command, cancellationToken);
        _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
        return Accepted(token);
    }
}
