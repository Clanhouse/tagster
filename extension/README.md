# Extension

1. Open console in folder "extension"
1. Get all dependences using command

```shell
yarn
```

1. Run local development server using:

```shell
yarn build
```

This command should create folder "build"

1. Open Chrome and go to: "chrome://extensions/"
1. Install extension in chrome:
   - Drag & drop folder "dist" on that page.
   - Another way to install:
     - click "bundle the extension" -> "extension root directory" -> "browse"
     - Find "dist" folder, open it, press "select folder" -> "bundle the extension"
     - Now, click "Load unpacked" -> choose same folder as previous & press "select folder"
1. Extension installed. Click on puzzle icon, in the upper right corner of the screen to use and manage.
