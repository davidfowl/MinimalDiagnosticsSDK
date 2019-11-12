using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication21App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Profiler API would inject this
            InitializeDiagnostics();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        // Profiler API would inject this IL
        private static void InitializeDiagnostics()
        {
            var path = Environment.GetEnvironmentVariable("DIAGNOSTICS_PATH");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            }
            catch
            {
                // Swallow this exception, we couldn't load the diagnostics assembly
            }
        }
    }
}
