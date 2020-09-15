# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY MusalaGateway.Api/*.csproj MusalaGateway.Api/
COPY MusalaGateway.Core/*.csproj MusalaGateway.Core/
COPY MusalaGateway.Data/*.csproj MusalaGateway.Data/
COPY MusalaGateway.Services/*.csproj MusalaGateway.Services/
COPY MusalaGateway.Tests/*.csproj MusalaGateway.Tests/

RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/MusalaGateway.Api
RUN dotnet build
WORKDIR /src/MusalaGateway.Tests
RUN dotnet test -v n

# publish
FROM build AS publish
WORKDIR /src/MusalaGateway.Api
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "MusalaGateway.Api.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MusalaGateway.Api.dll