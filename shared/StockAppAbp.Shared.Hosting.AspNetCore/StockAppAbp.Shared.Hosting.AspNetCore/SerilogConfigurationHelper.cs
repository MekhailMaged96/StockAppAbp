using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using Serilog;
using Serilog.Formatting.Json;

namespace StockAppAbp.Shared.Hosting.AspNetCore
{
    public class SerilogConfigurationHelper
    {
        public static void Configure(string applicationName)
        {
            Log.Logger = new LoggerConfiguration()
                        #if DEBUG
                        .MinimumLevel.Debug()
                        #else
                        .MinimumLevel.Information()
                        #endif
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ApplicationName", applicationName)
                        .WriteTo.Async(c => c.File(
                                            new JsonFormatter(),
                                            path: $"../../../../logs/{applicationName}/log-.txt",
                                            rollingInterval: RollingInterval.Day,
                                            retainedFileCountLimit: 30, // Optional: keep last 30 days
                                            shared: true
                                        ))
                        .WriteTo.Async(c => c.Console())
                        .WriteTo.Seq("http://localhost:5341")
                        .CreateLogger();
        }
    }
}
