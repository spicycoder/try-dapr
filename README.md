# Run

```ps1
dapr run --app-id super-heroes --app-port 1901 --dapr-http-port 2501 --components-path ./components -- dotnet run --project ./SuperHeroes/SuperHeroes.csproj
dapr run --app-id contacts-provider --app-port 1801 --dapr-http-port 2502 --components-path ./components -- dotnet run --project ./ContactsProvider/ContactsProvider.csproj
```
