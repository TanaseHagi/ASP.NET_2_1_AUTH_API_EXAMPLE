
## Create the project

[Create a Web API with ASP.NET Core and Visual Studio Code](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1)

`dotnet new webapi -o TodoApi`

## Add Authentication

[Introduction to Identity on ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.1)

## Migrations

`dotnet ef migrations add InitialCreate --context ToDoItemContext`

`dotnet ef migrations add InitialCreate --context ToDoUserContext`

`dotnet ef database update --context ToDoItemContext`

`dotnet ef database update --context ToDoUserContext`

`dotnet ef database drop --context ToDoItemContext`

`dotnet ef database drop --context ToDoUserContext`
