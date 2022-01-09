# Dapr

## Service Invocation

Laun the application, with dapr sidecar

```ps1
dapr run --app-id conversionapi --app-port 1904 --dapr-http-port 2504 dotnet run
```

Access API Endpoint by calling

<http://localhost:2504/v1.0/invoke/conversionapi/method/api/Temperature/c-to-f?c=27>

---
