using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tagster.Auth.Dtos;
using Tagster.Auth.Models;
using Tagster.Auth.Services;
using Tagster.DataAccess.DBContexts;
using Tagster.DataAccess.Entities;

namespace Tagster.Application.Services
{
    public sealed class IdentityService : IIdentityService
    {
        private readonly ITagsterDbContext _tagsterDb;
        private readonly IPasswordService _passwordService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(ITagsterDbContext tagsterDb, IPasswordService passwordService,
            IRefreshTokenService refreshTokenService, IAccessTokenService accessTokenService,
            ILogger<IdentityService> logger)
        {
            _tagsterDb = tagsterDb;
            _passwordService = passwordService;
            _refreshTokenService = refreshTokenService;
            _accessTokenService = accessTokenService;
            _logger = logger;
        }

        public async Task SignUpAsync(SignUp command)
        {
            var user = _tagsterDb.Users.FirstOrDefault(x => x.Email.Equals(command.Email));
            if (user is { })
            {
                _logger.LogInformation("Email already in use: {email}", command.Email);
                //throw new EmailInUseException(command.Email);
                throw new Exception("Email already in use");
            }

            var password = _passwordService.Hash(command.Password);
            user = new User(Guid.NewGuid(), command.Email, password, DateTime.UtcNow);
            await _tagsterDb.Users.AddAsync(user);

            _logger.LogInformation("Created an account for the user with id: {id}.", user.Id);
        }

        public async Task<AuthDto> SignInAsync(SignIn command)
        {
            //var user = await _userRepository.GetAsync(command.Email);
            //if (user is null || !_passwordService.IsValid(user.Password, command.Password))
            //{
            //    _logger.LogError($"User with email: {command.Email} was not found.");
            //    throw new InvalidCredentialsException(command.Email);
            //}

            //if (!_passwordService.IsValid(user.Password, command.Password))
            //{
            //    _logger.LogError($"Invalid password for user with id: {user.Id.Value}");
            //    throw new InvalidCredentialsException(command.Email);
            //}

            //var auth = _jwtProvider.Create(user.Id, user.Email);
            //auth.RefreshToken = await _refreshTokenService.CreateAsync(user.Id);

            //_logger.LogInformation($"User with id: {user.Id} has been authenticated.");

            //return auth;

            throw new NotImplementedException();
        }

        public async Task SignOutAsync(SignOut command)
        {
            //if (string.IsNullOrEmpty(command.AccessToken))
            //{
            //    _logger.LogError("Access token can't be null or empty");
            //    throw new EmptyAccessTokenException();
            //}

            //if (string.IsNullOrEmpty(command.RefreshToken))
            //{
            //    _logger.LogError("Refresh token can't be null or empty");
            //    throw new EmptyRefreshTokenException();
            //}

            //await _accessTokenService.DeactivateCurrentAsync();
            //await _refreshTokenService.RevokeAsync(command.RefreshToken);
        }
    }
}
