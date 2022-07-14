# Tagster

Tagster is a backend and frontend application that allows you to add tags to browsed profiles on [LinkedIn](https://www.linkedin.com).

## Prerequisites

You need install:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)
- [Chrome](https://www.google.com/chrome)
- [NPM](https://nodejs.org/)

## Usage

1. Clone the repository

### Backend

#### Docker

2. Go to [README.docker.md](./README.docker.md) and follow the instructions.

#### Source build

2. Open terminal and go to folder [TagsterWebAPI](./TagsterWebAPI).
3. Generate sql srcipt to initialize database:

- go to [TagsterWebAPI](./TagsterWebAPI/src/TagsterWebAPI) folder with .Net project
- open [appsettings.json](./TagsterWebAPI/src/TagsterWebAPI/Configuration/appsettings.json) and update `conectionString` for section `database`. More information about building connection string [here](https://www.connectionstrings.com/postgresql/)
- go to [TagsterWebAPI](./TagsterWebAPI) folder with .Net solution

4. Build and publish application with commands below

```shell
dotnet build -c Release -o Publish
```

5. Go to `./TagsterWebAPI/Publish` folder.
6. Configure `appsettings.json`. To see more go to [backend configuration](./TagsterWebAPI/README.md)
7. Start application

```shell
TagsterWebAPI.exe
```

### Extension

2. Go to instructions folder [./extension/README.md](./extension/README.md)
