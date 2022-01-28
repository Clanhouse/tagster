using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tagster.Application.Exceptions;
using Tagster.Auth.Dtos;
using Tagster.Auth.Exceptions;
using Tagster.Auth.Models;
using Tagster.Auth.Services;
using Tagster.Domain.Entities;
using Tagster.Domain.Repositories;

namespace Tagster.Application.Services;

public sealed class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IJwtProvider _jwtProvider;
    private readonly IAccessTokenService _accessTokenService;
    private readonly ILogger<IdentityService> _logger;

    public IdentityService(IUserRepository userRepository, IPasswordService passwordService,
        IRefreshTokenService refreshTokenService, IJwtProvider jwtProvider,
        IAccessTokenService accessTokenService, ILogger<IdentityService> logger)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _refreshTokenService = refreshTokenService;
        _jwtProvider = jwtProvider;
        _accessTokenService = accessTokenService;
        _logger = logger;
    }

    public async Task SignUpAsync(SignUp command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(command.Email, cancellationToken);
        if (user is { })
        {
            _logger.LogInformation("Email already in use: {email}", command.Email);
            throw new EmailInUseException(command.Email);
        }

        await CreateUser(command, cancellationToken);
    }

    private async Task CreateUser(SignUp command, CancellationToken cancellationToken)
    {
        string password = command.Password is not null ? _passwordService.Hash(command.Password) : null;
        var user = new User(0, command.Email, password, DateTime.UtcNow);
        await _userRepository.AddAsync(user, cancellationToken);
        _logger.LogInformation("Created an account for the user with id: {Id}", user.Id);
    }

    public async Task<AuthDto> SignInAsync(SignIn command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(command.Email, cancellationToken);
        if (user is null || !_passwordService.IsValid(user.Password, command.Password))
        {
            _logger.LogInformation("User with email: {email} was not found or password is incorrect.", command.Email);
            throw new InvalidCredentialsException(command.Email);
        }

        return await CreateAuthDto(user);
    }

    private async Task<AuthDto> CreateAuthDto(User user)
    {
        var auth = _jwtProvider.Create(user.Id, user.Email);
        auth.RefreshToken = await _refreshTokenService.CreateAsync(user.Id);
        _logger.LogInformation("User with id: {id} has been authenticated.", user.Id);
        return auth;
    }

    public async Task SignOutAsync(SignOut command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(command.AccessToken))
        {
            _logger.LogError("Access token can't be null or empty");
            throw new EmptyAccessTokenException();
        }

        if (string.IsNullOrEmpty(command.RefreshToken))
        {
            _logger.LogError("Refresh token can't be null or empty");
            throw new EmptyRefreshTokenException();
        }

        await _accessTokenService.DeactivateCurrentAsync();
        await _refreshTokenService.RevokeAsync(command.RefreshToken);
    }

    public async Task<AuthDto> ExternalAuth(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(email, cancellationToken);
        if (user is not null) return await CreateAuthDto(user);

        await CreateUser(new SignUp(email, null), cancellationToken);
        return await CreateAuthDto(await _userRepository.FindByEmailAsync(email, cancellationToken));
    }
}
