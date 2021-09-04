# Configuration

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
    "contactEmail": "tagster@support.com"
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
    "seq": {
      "enabled": true,
      "url": "http://localhost:5341",
      "apiKey": "secret"
    }
  }
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
