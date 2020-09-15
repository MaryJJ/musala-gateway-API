![Logo of the project](https://github.com/MaryJJ/musala-gateway-WebApp/raw/master/logo.png)

"Surround yourself with successful people. You can't be what you can't see."

# Musala Gateway

Musala Gateway is a project to manage the company's gateways as well as the devices that connect through them. Allowing us to keep control over Gateway IP and device identifiers, the system allows us to access information through a REST API.

Basic Actions: 
* List the company's active Gateways, edit their information, and the associated devices. 
* Set device status (offline, online)
* Edit information of the devices.

This project is a REST API and works independently of the visual client, we recommended using the visual interface you will find [here]https://github.com/MaryJJ/musala-gateway-WebApp

## Software Requirements

* Programming languages: C#
* Framework: ASP.NET Core 3.1
* Database: in-memory
* Automated build: Docker 
* UI: [Angular]https://github.com/MaryJJ/musala-gateway-WebApp

## Project structure

```
MusalaGateway.Api/           point of access for application
MusalaGateway.Core/          application's foundation, hold contracts (interfaces …), models and everything else that is essential
MusalaGateway.Data/          access layer
MusalaGateway.Services/      business logic
MusalaGateway.Test/          unit testing
```

## Installing / Getting started

Open command prompt in project folder and execute the follow commands:

```shell
dotnet test -v n
dotnet publish -c Release -o /publish 
dotnet /publish/MusalaGateway.Api.dll
```
* Api: [https://localhost:5001/api]
* Swagger documentation:
[https://localhost:5001/explorer]

Or publish with Docker:

```shell
docker build -t musalagateway . 
docker run -d -p 8080:80 --name MusalaGateway.Api musalagateway
```
* Api: [http://localhost:8080/api]
* Swagger documentation:
[http://localhost:8080/explorer]

### Initial Configuration

The database is automatically seed with test data.

## Developing

```shell
git clone https://github.com/MaryJJ/musala-gateway-API.git
```

### Deploying / Publishing

Automatic deploy to heroku with docker and Github Actions:

```shell
.github/workflows/heroku.yml
```
The environment variable HEROKU_API_KEY was set in Github Secret.

## Links

Demo online:

- WebApp: https://musalagateway.web.app
- Api: https://musala-gateway-api.herokuapp.com/api
- Swagger documentation: https://musala-gateway-api.herokuapp.com/explorer