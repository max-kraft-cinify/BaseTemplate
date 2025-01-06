using System.IO.Abstractions;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.DAL.UseCases.Configurations;
using BaseTemplate.DAL.UseCases.Configurations.Read;
using BaseTemplate.PAL.UseCases.Configurations.Read;
using Microsoft.Extensions.DependencyInjection;

namespace BaseTemplate.MAIN.Core;

public static class InjectorConfiguration
{
    public static void RegisterComponents(IServiceCollection services)
    {
        services.AddTransient<IFileSystem, FileSystem>();
        services.AddTransient<IConfigurationReadRepository, ConfigurationReadRepository>();
        services.AddTransient<IConfigurationReadService, ConfigurationReadService>();
        services.AddAutoMapper(mapperConfigurationExpression =>
        {
            mapperConfigurationExpression.AllowNullCollections = false;
            mapperConfigurationExpression.AddProfile<ConfigurationMappingProfile>();
            mapperConfigurationExpression.AddProfile<ConfigurationDtoMappingProfile>();
        });
    }
    
}