## ASP.NET Core 2.1 sample

```JSON
{
    "profiles": {
        "IIS Express": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "DOTNET_ADDITIONAL_DEPS": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\additionalDeps",
            "DOTNET_SHARED_STORE": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\store",
            "ASPNETCORE_ENVIRONMENT": "Development",
            "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
          }
        },
        "WebApplication21App": {
          "commandName": "Project",
          "launchBrowser": true,
          "environmentVariables": {
            "DOTNET_ADDITIONAL_DEPS": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\additionalDeps",
            "DOTNET_SHARED_STORE": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\store",
            "ASPNETCORE_ENVIRONMENT": "Development",
            "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
          },
          "applicationUrl": "https://localhost:5001;http://localhost:5000"
    }
}
```