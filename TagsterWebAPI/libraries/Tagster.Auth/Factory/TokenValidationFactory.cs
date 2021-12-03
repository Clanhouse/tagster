using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Tagster.Auth.Options;

namespace Tagster.Auth.Factory;

internal static class TokenValidationFactory
{
    public static TokenValidationParameters CreateParameters(JwtOptions options)
    {
        return new()
        {
            RequireAudience = options.RequireAudience,
            ValidIssuer = options.ValidIssuer,
            ValidIssuers = options.ValidIssuers,
            ValidateActor = options.ValidateActor,
            ValidAudience = options.ValidAudience,
            ValidAudiences = options.ValidAudiences,
            ValidateAudience = options.ValidateAudience,
            ValidateIssuer = options.ValidateIssuer,
            ValidateLifetime = options.ValidateLifetime,
            ValidateTokenReplay = options.ValidateTokenReplay,
            ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
            SaveSigninToken = options.SaveSignInToken,
            RequireExpirationTime = options.RequireExpirationTime,
            RequireSignedTokens = options.RequireSignedTokens,
            ClockSkew = TimeSpan.Zero
        };
    }

    public static void AddAuthenticationType(this TokenValidationParameters tokenValidationParameters,
        JwtOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.AuthenticationType))
        {
            tokenValidationParameters.AuthenticationType = options.AuthenticationType;
        }
    }

    public static void AddIssuerSigningKey(this TokenValidationParameters tokenValidationParameters,
        JwtOptions options)
    {
        var hasCertificate = false;
        if (options.Certificate is { })
        {
            X509Certificate2 certificate = null;
            var password = options.Certificate.Password;
            var hasPassword = !string.IsNullOrWhiteSpace(password);
            if (!string.IsNullOrWhiteSpace(options.Certificate.Location))
            {
                certificate = hasPassword
                    ? new X509Certificate2(options.Certificate.Location, password)
                    : new X509Certificate2(options.Certificate.Location);
            }

            if (!string.IsNullOrWhiteSpace(options.Certificate.RawData))
            {
                var rawData = Convert.FromBase64String(options.Certificate.RawData);
                certificate = hasPassword
                    ? new X509Certificate2(rawData, password)
                    : new X509Certificate2(rawData);
            }

            if (certificate is { })
            {
                if (string.IsNullOrWhiteSpace(options.Algorithm))
                {
                    options.Algorithm = SecurityAlgorithms.RsaSha256;
                }

                hasCertificate = true;
                tokenValidationParameters.IssuerSigningKey = new X509SecurityKey(certificate);
            }
        }
        if (!string.IsNullOrWhiteSpace(options.IssuerSigningKey) && !hasCertificate)
        {
            if (string.IsNullOrWhiteSpace(options.Algorithm) || hasCertificate)
            {
                options.Algorithm = SecurityAlgorithms.HmacSha256;
            }

            var rawKey = Encoding.UTF8.GetBytes(options.IssuerSigningKey);
            tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(rawKey);
        }
    }

    public static void AddNameClaimType(this TokenValidationParameters tokenValidationParameters,
        JwtOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.NameClaimType))
        {
            tokenValidationParameters.NameClaimType = options.NameClaimType;
        }
    }

    public static void AddRoleClaimType(this TokenValidationParameters tokenValidationParameters,
        JwtOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.RoleClaimType))
        {
            tokenValidationParameters.RoleClaimType = options.RoleClaimType;
        }
    }
}
