## ASP.NET Core 2.1 sample

```JSON
{
    "profiles": {
        "IIS Express": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "DIAGNOSTICS_PATH": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\Diagnostics.Core.dll",
            "ASPNETCORE_ENVIRONMENT": "Development",
            "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
          }
        },
        "WebApplication21App": {
          "commandName": "Project",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "DIAGNOSTICS_PATH": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\Diagnostics.Core.dll",
            "ASPNETCORE_ENVIRONMENT": "Development",
            "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
          },
          "applicationUrl": "https://localhost:5001;http://localhost:5000"
    }
}
```