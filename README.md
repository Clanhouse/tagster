# Tagster

Tagster is a backend and frontend application that allows you to add tags to browsed profiles on [LinkedIn](https://www.linkedin.com).

## Prerequisites

You need install:

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)
- [Chrome](https://www.google.com/chrome)
- [NPM](https://nodejs.org/)

## Usage

1. Clone the repository

### Backend

2. Open terminal and go to folder [TagsterWebAPI](./TagsterWebAPI).
3. Generate sql srcipt to initialize database:

- go to [TagsterWebAPI](./TagsterWebAPI/src/TagsterWebAPI) folder with .Net project
- open [appsettings.json](./TagsterWebAPI/src/TagsterWebAPI/appsettings.json) and update `defaultConnection` for section `connectionStrings`
- go to [TagsterWebAPI](./TagsterWebAPI) folder with .Net solution
- generate scl script with command

```bash
dotnet ef dbcontext script -p .\libraries\Tagster.DataAccess\Tagster.DataAccess.csproj -s .\src\TagsterWebAPI\TagsterWebAPI.csproj -o script.sql
```

- use generated script to initialize database

4. Build and publish application with commands below

```shell
dotnet build -c Release -o Publish
```

5. Go to `Publish` folder.
6. Configure `appsettings.json`. To see more go to [backend configuration](./TagsterWebAPI/README.md)
7. Start application

```shell
TagsterWebAPI.exe
```

### Extension

2. Open console in folder "extension"
3. Get all dependences using command

```shell
npm install
```

4. Run local development server using:

```shell
npm run serve
```

This command should create folder "dist"

5. Open Chrome and go to: "chrome://extensions/"
6. Install extension in chrome:
   - Drag & drop folder "dist" on that page.
   - Another way to install:
     - click "bundle the extension" -> "extension root directory" -> "browse"
     - Find "dist" folder, open it, press "select folder" -> "bundle the extension"
     - Now, click "Load unpacked" -> choose same folder as previous & press "select folder"
7. Extension installed. Click on puzzle icon, in the upper right corner of the screen to use and manage.
