## Entity framework Migration

### When Clean Architecture

#### Create Migration

```bash
dotnet ef migrations add InitialCreate --project Restaurants.Infrastructure --startup-project Restaurants.API
```

#### Update Database

```bash
dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.API
```

### Common use

#### Create Migration

```bash
dotnet ef migrations add InitialCreate
```

#### Update Database

```bash
dotnet ef database update
```
