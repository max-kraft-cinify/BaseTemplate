using System;
using System.Diagnostics;
using System.Linq;
using BaseTemplate.BLL.Workers;
using BaseTemplate.MAIN.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace BaseTemplate.MAIN;

public class Program
{
    public static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;
        var isService = !(Debugger.IsAttached || args.Contains("--console") || isDevelopment);

        var host = (isService && OperatingSystem.IsWindows()) ? CreateHostBuilder(args).UseWindowsService().Build() : CreateHostBuilder(args).Build();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostBuildingContext, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConfiguration(hostBuildingContext.Configuration.GetSection("Logging"));
                loggingBuilder.SetMinimumLevel(hostBuildingContext.Configuration.GetSection("Logging:LogLevel")
                    .Get<LogLevel>());
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                if (OperatingSystem.IsWindows())
                {
                    loggingBuilder.AddEventLog(hostBuildingContext.Configuration.GetSection("Logging:EventLog")
                        .Get<EventLogSettings>());
                }

                if (OperatingSystem.IsLinux())
                {
                    loggingBuilder.AddSystemdConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.TimestampFormat = "hh:mm:ss ";
                    });
                }
            })
            .ConfigureServices(services =>
            {
                services.Configure<HostOptions>(hostOptions =>
                {
                    hostOptions.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
                });
                services.AddHostedService<StartupInitializeWorker>();
                InjectorConfiguration.RegisterComponents(services);
            });
        
}