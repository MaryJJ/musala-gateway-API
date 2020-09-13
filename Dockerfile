# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY MusalaGateway.API/*.csproj MusalaGateway.API/
COPY MusalaGateway.Core/*.csproj MusalaGateway.Core/
COPY MusalaGateway.Data/*.csproj MusalaGateway.Data/
COPY MusalaGateway.Services/*.csproj MusalaGateway.Services/

RUN dotnet restore
COPY . .

# build
WORKDIR /src/MusalaGateway.API
RUN dotnet build
WORKDIR /src/MusalaGateway.Core
RUN dotnet build
WORKDIR /src/MusalaGateway.Data
RUN dotnet build
WORKDIR /src/MusalaGateway.Services
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/MusalaGateway.API
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MusalaGateway.API.dll