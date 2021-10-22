# Running application using docker and docker-compose will fail

## Prerequisites

You need install docker and docker-compose:

- [Mac](https://docs.docker.com/desktop/mac/install/)
- [Windows](https://docs.docker.com/desktop/windows/install/)
- [Linux docker](https://docs.docker.com/engine/install/) / [Linux docker-compose](https://docs.docker.com/compose/install/)

## Usage

Create defined volumes from [docker-compose.yml](./docker-compose.yml) using below command changing name of volume:

```bash
docker volume create --name=db-mssql
```

Build and start containers:

```bash
docker-compose -f docker-compose.yml build
docker-compose -f docker-compose.yml up -d
```

If you want stop all containers use:

```bash
docker-compose -f docker-compose.yml down
```