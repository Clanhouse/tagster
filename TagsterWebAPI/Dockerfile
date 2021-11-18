ARG VERSION=5.0

FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build
WORKDIR /app
ARG CONFIGURATION=Release
COPY . .
RUN dotnet restore

RUN dotnet publish \
    -c $CONFIGURATION \
    -o publish \
    --no-restore \
    --force

FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
EXPOSE 5000
WORKDIR /app
CMD [ "TagsterWebAPI.dll" ]
ENV DOTNET_RUNNING_IN_CONTAINER=true \
    ASPNETCORE_ENVIRONMENT=Docker 
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet" ]