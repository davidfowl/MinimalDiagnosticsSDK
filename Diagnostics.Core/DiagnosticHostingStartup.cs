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

[assembly: HostingStartup(typeof(DiagnosticHostingStartup))]

namespace Diagnostics.Core
{
    internal class DiagnosticHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddHostedService<DiagnosticsHosted>();

                services.AddLogging(b =>
                {
                    // Add a logger provider to capture logs
                    b.AddProvider(new DiagnosticLoggerProvider());
                });
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
            // Resolve the ASP.NET Core version
            var aspNetCoreVersion = (AspNetCoreMajorVersion)int.Parse((typeof(IWebHostBuilder).GetType().Assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion ?? "1.0.0").Split('.')[0]);

            var client = new TelemetryClient();
            var applicationIdProvider = new ApplicationIdProvider();
            _hostingDiagnosticListener = new HostingDiagnosticListener(client, applicationIdProvider, injectResponseHeaders: false, trackExceptions: true, enableW3CHeaders: false, aspNetCoreVersion);
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
