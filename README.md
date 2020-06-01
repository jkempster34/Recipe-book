[![Build and Test](https://github.com/jkempster34/web-form-asp.net-react/workflows/.NET%20Core/badge.svg)](https://github.com/jkempster34/web-form-asp.net-react/actions)

# Recipe-book

Note: If you need to create migrations, you can use these commands:
```
IdentityDb

-- create migration (CLI)
dotnet ef migrations add InitialIdentityModel --context appidentitydbcontext -o Identity/Migrations

or (from the Package Manager Console in Visual Studio)
Add-Migration InitialIdentityModel -Context AppIdentityDbContext -OutputDir DataIdentity/Migrations


RecipeBookDb
```