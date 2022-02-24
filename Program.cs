using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ConsoleInsightsWebJob
{
    class Program
    {
        // This is async but doesn't need to be unless the timer method we use is going to be async.
        static async Task Main()
        {
            // We're going to do this HostBuilder style, which is a great setup. Change Environment to Production when ready.
            var builder = new HostBuilder();
            builder.UseEnvironment(EnvironmentName.Development);

            // Only need this ConfigureWebJobs section since we're using WebJobs, if moved do a different model, we can remove this.
            builder.ConfigureWebJobs(b =>
            {
                // The Storage Core Services are required, and you neeed an azure storage account to make them work.
                // We need timers here also to actually do the timer job.
                b.AddAzureStorageCoreServices();
                b.AddTimers();
            });
            builder.ConfigureLogging((context, b) =>
            {
                // AddConsole gives us the ability to see a bunch of things in the console.
                b.AddConsole();
                b.SetMinimumLevel(LogLevel.Trace);

                // Here is where we set up Application Insights. :)
                string instrumentationKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                if (!string.IsNullOrEmpty(instrumentationKey))
                {
                    b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = instrumentationKey);
                }
            })
            .ConfigureServices(services =>
             {
                 // Dependnacy Inject the good stuff including the class that does our work, as well as the CustomTelemetryInitializer.
                 services.AddSingleton<SimpleService>();
                 services.AddSingleton<ITelemetryInitializer, CustomTelemetryInitializer>();
             }).UseConsoleLifetime();

            IHost host = builder.Build();
            using (host)
            {
                // Cowabunga!
                host.Run();
            }
        }
    }
}
