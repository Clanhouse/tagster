# Configuration

## Table of Contents

1. [Swagger](#Swagger)
2. [Logger](#Logger)
3. [Redis](#Redis)
4. [Jwt](#Jwt)
5. [ConnectionStrings](#ConnectionStrings)

Example `appsetings.json` configuration file.

```json
{
  "swagger": {
    "enabled": false,
    "name": "tagster",
    "title": "tagster",
    "version": "v1",
    "routePrefix": "docs",
    "includeSecurity": true,
    "contactName": "support",
    "contactEmail": ""
  },
  "logger": {
    "level": "information",
    "excludePaths": ["/ping", "/metrics"],
    "excludeProperties": [
      "api_key",
      "access_key",
      "ApiKey",
      "ApiSecret",
      "ClientId",
      "ClientSecret",
      "ConnectionString",
      "Password",
      "Email",
      "Login",
      "Secret",
      "Token"
    ],
    "console": {
      "enabled": false
    },
    "file": {
      "enabled": false,
      "Path": "",
      "Interval": "day"
    },
    "elk": {
      "enabled": false,
      "url": "",
      "basicAuthEnabled": false,
      "username": "",
      "password": "",
      "indexFormat": ""
    },
    "seq": {
      "enabled": true,
      "url": "http://localhost:5341",
      "apiKey": "secret"
    }
  },
  "redis": {
    "connectionString": "localhost",
    "instance": "identity:"
  },
  "jwt": {
    "issuerSigningKey": "eiquief5phea902zo0Faddaez1gohThailiua5woa2befiech1oarai4aiLi6ahVecah3ie9Aiz6Peij",
    "expiryMinutes": 5,
    "issuer": "SCL",
    "audience": "User",
    "validateAudience": false,
    "validateIssuer": false,
    "validateLifetime": true,
    "allowAnonymousEndpoints": ["/sign-in", "/sign-up"]
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(server name);Database=Tagster;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AllowedHosts": "*"
}
```

## Description of individual sections

### Swagger

```json
"swagger": {
    "enabled": true,
    "name": "some-name",
    "title": "title-of-document",
    "version": "version-of-document",
    "routePrefix": "route-prefix",
    "includeSecurity": true,
    "contactName": "some-name",
    "contactEmail": "some.email@example.com"
}
```

- Enabled - determines whether documentation is enabled.
- Name - name of the documentation.
- Title - title of the documentation.
- Version - version of the documentation.
- RoutePrefix - endpoint at which the documentation is going to be available. E.g. `routePrefix` equal `docs` and application run on port `5000`, you find swagger documentaion uder url `localhost:5000/docs`.
- IncludeSecurity - determines whether documentation security (via JWT) is going to be activated.
- ContactName - name of person which we can contact.
- ContactEmail - email of person which we can contact.

### Logger

```json
"logger": {
    "level": "information",
    "excludePaths": ["/ping", "/metrics"],
    "excludeProperties": [
      "api_key",
      "access_key",
      "ApiKey",
      "ApiSecret",
      "ClientId",
      "ClientSecret",
      "ConnectionString",
      "Password",
      "Email",
      "Login",
      "Secret",
      "Token"
    ],
    "console": {
      "enabled": false
    },
    "file": {
      "enabled": false,
      "Path": "",
      "Interval": "day"
    },
    "seq": {
      "enabled": true,
      "url": "http://localhost:5341",
      "apiKey": "secret"
    }
  }
```

- Level - logging level. You can set it on (by default is set "Information"):
  - "Verbose" - Anything and everything you might want to know about a running block of code.
  - "Debug" - Internal system events that aren't necessarily observable from the outside.
  - "Information" - The lifeblood of operational intelligence - things happen.
  - "Warning" - Service is degraded or endangered.
  - "Error" - Functionality is unavailable, invariants are broken or data is lost.
  - "Fatal" - If you have a pager, it goes off when one of these occurs.
- ExcludePaths - optional endpoints that should be excluded from logging (e.g. while performing the health checks by other services).
- ExcludeProperties - excluded properties from loged information.
- Console
  - Enabled - enables/disables console logger.
- File - options to save logs to file.
  - Enabled - enables/disables file logger.
  - Path - path to the file logs.
  - Interval - how often should the new file with logs be created. Allowed types:
    - "Infinite" - the log file will never roll, no time period information will be appended to the log file name.
    - "Year" - Roll every year. Filenames will have a four-digit year appended in the pattern yyyy.
    - "Month" - Roll every calendar month. Filenames will have yyyyMM appended.
    - "Day" - Roll every day. Filenames will have yyyyMMdd appended.
    - "Hour"- Roll every hour. Filenames will have yyyyMMddHH appended.
    - "Minute" - Roll every minute. Filenames will have yyyyMMddHHmm appended.
- Seq - service to aggregate logs.
  - Enabled - enables/disables Seq logger.
  - Url - URL to Seq API.
  - Token - API key (if provided) used while sending logs to Seq.

### Redis

- connectionString - connection string e.g. localhost.
- instance - optional prefix, that will be added by default to all the keys.

```json
"redis": {
  "connectionString": "localhost",
  "instance": "some-prefix:"
}
```

### Jwt

- allowAnonymousEndpoints - list of anonymous endpoints used to send request to specific routes.
- certificate - if is not null algorithm use specific certificate else use symmetric key.
  - location - certyficate location.
  - rawData - a byte array containing data from an X.509 certificate.
  - password - the password required to access the X.509 certificate data
- issuer - if this value is not null, a { iss, 'issuer' } claim will be added.
- issuerSigningKey - it's used to set key for symmetric security key.
- authority - gets or sets the Authority to use when making OpenIdConnect calls.
- challenge - gets or sets the challenge to put in the "WWW-Authenticate" header.
- metadataAddress - gets or sets the discovery endpoint for obtaining metadata.
- expiryMinutes - it's minutes which is added to actual time
- expiry - it's total milliseconds which is added to actual time (`TimeSpan`).
- validAudience - Gets or sets a string that represents a valid audience that will be used to check against the token's audience.
- validAudiences - gets or sets the System.Collections.Generic.IEnumerable`1 that contains valid audiences that will be used to check against the token's audience.
- validIssuer - gets or sets a System.String that represents a valid issuer that will be used to check against the token's issuer.
- validIssuers - gets or sets the System.Collections.Generic.IEnumerable`1 that contains valid issuers that will be used to check against the token's issuer.
- authenticationType - gets or sets the AuthenticationType when creating a System.Security.Claims.ClaimsIdentity.
- nameClaimType - gets or sets a System.String that defines the System.Security.Claims.ClaimsIdentity.NameClaimType.
- roleClaimType - gets or sets the System.String that defines the System.Security.Claims.ClaimsIdentity.RoleClaimType.
- saveToken - defines whether the bearer token should be stored in the Microsoft.AspNetCore.Authentication.AuthenticationProperties after a successful authorization. **Default true.**
- saveSignInToken - gets or sets a boolean to control if the original token should be saved after the security token is validated.
- requireAudience - gets or sets a value indicating whether SAML tokens must have at least one AudienceRestriction. **Default true.**
- requireHttpsMetadata - gets or sets if HTTPS is required for the metadata address or authority. This should be disabled only in development environments. **Default true.**
- requireExpirationTime - gets or sets a value indicating whether tokens must have an 'expiration' value. **Default true.**
- requireSignedTokens - gets or sets a value indicating whether a Microsoft.IdentityModel.Tokens.SecurityToken can be considered valid if not signed. **Default true.**
- validateActor - gets or sets a value indicating if an actor token is detected, whether it should be validated.
- validateAudience - gets or sets a boolean to control if the audience will be validated during token validation. **Default true.**
- validateIssuer - gets or sets a boolean to control if the issuer will be validated during token validation. **Default true.**
- validateLifetime - gets or sets a boolean to control if the lifetime will be validated during token validation. **Default true.**
- validateTokenReplay - gets or sets a boolean to control if the token replay will be validated during token validation.
- validateIssuerSigningKey - gets or sets a boolean that controls if validation of the Microsoft.IdentityModel.Tokens.SecurityKey that signed the securityToken is called.
- refreshOnIssuerKeyNotFound - gets or sets if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. This allows for automatic recovery in the event of a signature key rollover. **Default true.**
- includeErrorDetails - defines whether the token validation errors should be returned to the caller. Enabled by default, this option can be disabled to prevent the JWT handler from returning an error and an error_description in the WWW-Authenticate header. **Default true.**

```json
"jwt": {
  "certificate": {
    "location": "certs/localhost.pfx",
    "password": "test",
    "rawData": ""
  },
  "issuerSigningKey": "eiquief5phee9pazo0Faegaez9gohThailiur5woy2befiech1oarai4aiLi6ahVecah3ie9Aiz6Peij",
  "expiryMinutes": 60,
  "issuer": "issuer",
  "validateAudience": false,
  "validateIssuer": false,
  "validateLifetime": true,
  "allowAnonymousEndpoints": ["/sign-in", "/sign-up"]
}
```

### ConnectionStrings

- defaultConnection - sql connection string.

```json
"connectionStrings": {
  "defaultConnection": "Server=(server name);Database=Tagster;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```
