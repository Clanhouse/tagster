# Tagster

Tagsster is a backend and frontend application that allows you to add tags to browsed profiles on [LinkedIn](https://www.linkedin.com).

## Prerequisites

You need install:

- [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)
- [Chrome](https://www.google.com/chrome)

## Usage

1. Clone the repository

### Backend

2. Open terminal and go to folder [`TagsterWebAPI`](./TagsterWebAPI).
3. Build and publish application with commands below

```shell
dotnet build -c Release -o Publish
```

4. Go to `Publish` folder.
5. Configure `appsettings.json`. To see more go to [backend configuration](./TagsterWebAPI/README.md)
6. Start application

```shell
TagsterWebAPI.exe
```

After start you should see logs from application.

### Extension

2. Open Chrome and go to: "chrome://extensions/"
3. Install extension:
   - Drag & drop folder "extension" on that page.
   - Another way to install:
     - click "bundle the extension" -> "extension root directory" -> "browse"
     - Find Extension folder, open it, press "select folder" -> "bundle the extension"
     - Now, click "Load unpacked" -> choose same folder as previous & press "select folder"
4. Extension installed. Click on puzzle icon, in the upper right corner of the screen to use and manage.
