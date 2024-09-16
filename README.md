# Diagrama

## Visão Geral
![](/Docs/overview.png)

## Arquitetura
![](/Docs/architecture.png)

## Dependências
![](/Docs/dependencies.jpg)

## Dependências do Projeto
![](/Docs/project-dependencies.jpg)

## Fluxo de código
![](/Docs/flowchart.png)
![](/Docs/code-flow.jpg)

## Repositório e Unidade de Trabalho
![](/Docs/custom-repo-versus-db-context.png)

# Stacks Técnicas
- ASP.NET Core 8.0 (with .NET 8.0)
- ASP.NET WebApi Core
- ASP.NET Identity Core
- Entity Framework Core
- .NET Core Native DI
- AutoMapper
- FluentValidation
- MediatR
- Swagger UI
- MSSQL
- xUnit
- Moq
- FluentAssertions
- Polly
- Refit
- DbUp
- NPOI
- Quartz
- StyleCop

# Design Patterns
- Domain Driven Design
- Domain Events
- Domain Notification
- CQRS
- Event Sourcing
- Unit Of Work
- Repository & Generic Repository
- Inversion of Control / Dependency injection
- ORM
- Mediator
- Specification Pattern
- Options Pattern

# Pré-Configuração

- Config User Secret:
  + Find `<user_secrets_id>` at `DDD.Services.Api.csproj` > `UserSecretsId` (Free to change to any GUID/UUID)
  + Windows: `C:\Users\[UserName]\AppData\Roaming\Microsoft\UserSecrets\<user_secrets_id>\secrets.json`
  + Linux / macOS: `~/.microsoft/usersecrets/<user_secrets_id>/secrets.json`


- `secrets.json` for Windows:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DDD;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

- LocalDB is a packaging mechanism for SQL Server Express Edition, and is only available for Windows, use [Microsoft SQL Server](https://hub.docker.com/_/microsoft-mssql-server) or [Azure SQL Edge](https://hub.docker.com/_/microsoft-azure-sql-edge) for Linux / macOS

- `secrets.json` for Linux / macOS:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=<ip_address>,1433;Initial Catalog=aspnetcore-ddd;User ID=SA;pwd=<YourNewStrong@Passw0rd>;Integrated Security=False;ConnectRetryCount=0;MultipleActiveResultSets=True"
  }
}
```

# Como Executar

- For Visual Studio: `Select profile > Run (F5)`
- For VSCode: `Select configuration > Run (F5)`
- For Terminal:

```bash
dotnet build Src/DDD.Services.Api/DDD.Services.Api.csproj
dotnet run --project Src/DDD.Services.Api/DDD.Services.Api.csproj --launch-profile Dev
dotnet watch --project Src/DDD.Services.Api/DDD.Services.Api.csproj run
```

# Testando
- Terminal: `dotnet test`

# Docker

```sh
docker build -t aspnetcore-docker-image .
docker run -it --rm -p 3000:80 --name aspnetcore-docker-container aspnetcore-docker-image
docker run -d -p 3000:80 --name aspnetcore-docker-container aspnetcore-docker-image
```

- http://localhost:3000/

```bash
docker compose up -d
docker compose ps
docker compose stop
```

- http://localhost:80/

# Podman

```bash
podman build -t aspnetcore-docker-image .
podman run -it --rm -p 3000:80 --name aspnetcore-docker-container aspnetcore-docker-image
podman run -d -p 3000:80 --name aspnetcore-docker-container aspnetcore-docker-image
```

- http://localhost:3000/

```bash
podman-compose up -d
podman-compose ps
podman-compose stop
```

- http://localhost:80/

# Swagger (Apenas Dev env)
- http://localhost:5000/swagger

# Health check (Apenas Staging & Prod env)
- http://localhost:5000/hc-ui
- http://localhost:5000/hc-json
