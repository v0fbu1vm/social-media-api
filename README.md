# SocialMedia.Api
> A social media api using the onion architecture. 
> You can interact with other users by posting, commenting, following and messaging.

## Feautrues
- GraphQL
- Rest

## Built With
- [_ASP.NET Core 6.0_](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0)
- [_EntityFrameworkCore 6.0_](https://docs.microsoft.com/en-us/ef/core/)
- [_Hot Chocolate v12_](https://chillicream.com/docs/hotchocolate/get-started)

## Setup
1. To get started, clone the project.
```
git clone https://github.com/WaadSulaiman/SocialMedia.Api.git
```
2. Change the settings inside `SocialMedia.Infrastructure/AppSettings.cs`.
3. Do a migration to get the database up and ready.
```C#
dotnet ef migrations add InitialMigration --project SocialMedia.Infrastructure --startup-project SocialMedia.Rest
```
```C#
dotnet ef database update --project SocialMedia.Infrastructure --startup-project SocialMedia.Rest
```
4. Run.

## Endpoints
- GraphQL => `https://localhost:port/graphql/`
- Voyager => `https://localhost:port/graphql-voyager`
- Rest => `https://localhost:port/swagger/index.html`

## License
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/WaadSulaiman/SocialMedia.Api/blob/main/LICENSE.md)

Enjoy 👍.
