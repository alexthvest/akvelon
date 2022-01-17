# Online Shop Template

## Backend

- .NET 6, C# 10
- ASP.NET Core
- PostgresQL

## Fronted

- Vite
- React, Typescript
- TailwindCSS

# Migrations

- First of all you need to install `dotnet-ef` tool: https://docs.microsoft.com/en-us/ef/core/cli/dotnet

```sh
# Creating new migration

dotnet ef migrations add <NAME> -p ./server/src/OnlineShop.Infrastructure -s ./server/src/OnlineShop.Web -o Data/Migrations

# Updating database to new migration

dotnet ef database update -p ./server/src/OnlineShop.Infrastructure -s ./server/src/OnlineShop.Web
```
