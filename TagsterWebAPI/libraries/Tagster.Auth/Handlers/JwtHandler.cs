using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Tagster.Auth.Dates;
using Tagster.Auth.Models;
using Tagster.Auth.Options;

namespace Tagster.Auth.Handlers;

internal sealed class JwtHandler : IJwtHandler
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();
    private readonly JwtOptions _options;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly SigningCredentials _signingCredentials;

    public JwtHandler(JwtOptions options, TokenValidationParameters tokenValidationParameters)
    {
        var issuerSigningKey = tokenValidationParameters.IssuerSigningKey;
        if (issuerSigningKey is null)
        {
            throw new InvalidOperationException("Issuer signing key not set.");
        }

        if (string.IsNullOrWhiteSpace(options.Algorithm))
        {
            throw new InvalidOperationException("Security algorithm not set.");
        }

        _options = options;
        _tokenValidationParameters = tokenValidationParameters;
        _signingCredentials = new(issuerSigningKey, _options.Algorithm);
    }

    public JsonWebToken CreateToken(int userId, string email, string role)
    {
        var now = DateTime.UtcNow;
        List<Claim> jwtClaims = new()
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString()),
            new(ClaimTypes.Role, role),
        };

        if (!string.IsNullOrWhiteSpace(email))
        {
            jwtClaims.Add(new(ServerClaimNames.Email, email));
        }

        var expires = _options.Expiry.HasValue
            ? now.AddMilliseconds(_options.Expiry.Value.TotalMilliseconds)
            : now.AddMinutes(_options.ExpiryMinutes);

        JwtSecurityToken jwt = new(
            issuer: _options.Issuer,
            audience: _options.ValidAudience,
            claims: jwtClaims,
            notBefore: now,
            expires: expires,
            signingCredentials: _signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new()
        {
            AccessToken = token,
            RefreshToken = string.Empty,
            Id = userId,
        };
    }

    public JsonWebRefreshToken CreateRefreshToken(string accessToken, int userId)
    {
        _jwtSecurityTokenHandler.ValidateToken(accessToken, _tokenValidationParameters,
            out var validatedSecurityToken);
        if (validatedSecurityToken is not JwtSecurityToken jwt)
        {
            return null;
        }

        return new(new Guid(), userId,
            Convert.ToBase64String(RandomNumberGenerator.GetBytes(128)), jwt.ValidTo, DateTime.Now);
    }
}
