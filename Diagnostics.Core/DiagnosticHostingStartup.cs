using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Diagnostics.Core;
using Diagnostics.Core.AppInsights;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.AspNetCore.DiagnosticListeners;
using Microsoft.ApplicationInsights.AspNetCore.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

[assembly: HostingStartup(typeof(DiagnosticHostingStartup))]

namespace Diagnostics.Core
{
    internal class DiagnosticHostingStartup : IHostingStartup
    {
        internal static AspNetCoreMajorVersion AspNetCoreVersion;

        public void Configure(IWebHostBuilder builder)
        {
            // Resolve the ASP.NET Core version
            var informationalVersion = typeof(IWebHostBuilder).Assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion;
            AspNetCoreVersion = (AspNetCoreMajorVersion)int.Parse((informationalVersion ?? "1.0.0").Split('.')[0]);

            builder.ConfigureServices(services =>
            {
                services.AddHostedService<DiagnosticsHosted>();

                // 3.0 and up we'll use the built in LoggingEventSource
                if (AspNetCoreVersion < AspNetCoreMajorVersion.Three)
                {
                    services.AddLogging(b =>
                    {
                        // Add a logger provider to capture logs
                        b.Services.AddSingleton<ILoggerProvider, ApplicationInsightsLoggerProvider>();
                    });
                }
            });
        }
    }

    internal class DiagnosticsHosted : IHostedService, IDisposable, IObserver<KeyValuePair<string, object>>
    {
        private readonly DiagnosticListener _diagnosticListener;
        private readonly HostingDiagnosticListener _hostingDiagnosticListener;

        public DiagnosticsHosted(DiagnosticListener diagnosticListener)
        {
            _diagnosticListener = diagnosticListener;

            var client = new TelemetryClient();
            var applicationIdProvider = new ApplicationIdProvider();
            _hostingDiagnosticListener = new HostingDiagnosticListener(client, applicationIdProvider, injectResponseHeaders: false, trackExceptions: true, enableW3CHeaders: false, DiagnosticHostingStartup.AspNetCoreVersion);
        }

        public void Dispose()
        {
            _hostingDiagnosticListener.Dispose();
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(KeyValuePair<string, object> value)
        {
            _hostingDiagnosticListener.OnNext(value);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _hostingDiagnosticListener.OnSubscribe();

            _diagnosticListener.Subscribe(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
