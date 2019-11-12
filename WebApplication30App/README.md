## ASP.NET Core 3.0 sample

```JSON
{
    "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "weatherforecast",
      "environmentVariables": {
        "DOTNET_STARTUP_HOOKS": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\Diagnostics.Core.dll",
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
      }
    },
    "WebApplication30App": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "weatherforecast",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "DOTNET_STARTUP_HOOKS": "C:\\Users\\david\\source\\repos\\MinimalDiagnosticsSDK\\Diagnostics.Core\\bin\\Debug\\netcoreapp2.1\\Diagnostics.Core.dll",
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPNETCORE_HOSTINGSTARTUPASSEMBLIES": "Diagnostics.Core"
      }
    }
  }
}
```