using System;
using System.Threading;
using System.Threading.Tasks;
using BaseTemplate.PAL.Core.Read;
using BaseTemplate.PAL.UseCases.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BaseTemplate.BLL.Workers;

public class StartupInitializeWorker : BackgroundService
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public StartupInitializeWorker(IServiceProvider serviceProvider, ILogger<StartupInitializeWorker> logger)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var configurationReadService = scope.ServiceProvider.GetService<IBaseReadService<Configuration>>();
        configurationReadService.Read();
        _logger.LogDebug("Startup finished!");

        return Task.CompletedTask;
    }
}