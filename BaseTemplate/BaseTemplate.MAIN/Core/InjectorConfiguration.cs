using System.IO.Abstractions;
using BaseTemplate.BLL.Core.Create;
using BaseTemplate.BLL.Core.Delete;
using BaseTemplate.BLL.Core.FindById;
using BaseTemplate.BLL.Core.Update;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.BLL.UseCases.Users;
using BaseTemplate.DAL.Core.Create;
using BaseTemplate.DAL.Core.Delete;
using BaseTemplate.DAL.Core.FindById;
using BaseTemplate.DAL.Core.Update;
using BaseTemplate.DAL.UseCases.Configurations;
using BaseTemplate.DAL.UseCases.Configurations.Read;
using BaseTemplate.DAL.UseCases.Users;
using BaseTemplate.PAL.Core.Create;
using BaseTemplate.PAL.Core.Delete;
using BaseTemplate.PAL.Core.FindById;
using BaseTemplate.PAL.Core.Update;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations.Read;
using BaseTemplate.PAL.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BaseTemplate.MAIN.Core;

public static class InjectorConfiguration
{
    public static void RegisterComponents(IServiceCollection services)
    {
        services.AddTransient<IFileSystem, FileSystem>();
        services.AddAutoMapper(mapperConfigurationExpression =>
        {
            mapperConfigurationExpression.AllowNullCollections = false;
            mapperConfigurationExpression.AddProfile<ConfigurationMappingProfile>();
            mapperConfigurationExpression.AddProfile<ConfigurationDtoMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserDtoMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserUpdateModelMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserUpdateModelDtoMappingProfile>();
        });
        RegisterConfigurationDependencies(services);
        RegisterUserDependencies(services);
    }

    private static void RegisterUserDependencies(IServiceCollection services)
    {
        services.AddTransient<IBaseCreateRepository<UserDto>, BaseCreateRepository<UserDto, DbUser>>();
        services.AddTransient<IBaseCreateService<User>, BaseCreateService<User, UserDto>>();
        
        services.AddTransient<IBaseUpdateRepository<UserUpdateModelDto>, BaseUpdateRepository<UserUpdateModelDto, DbUser>>();
        services.AddTransient<IBaseUpdateService<UserUpdateModel>, BaseUpdateService<UserUpdateModel, UserUpdateModelDto>>();
        
        services.AddTransient<IBaseDeleteRepository<UserDto>, BaseDeleteRepository<UserDto, DbUser>>();
        services.AddTransient<IBaseDeleteService<User>, BaseDeleteService<User, UserDto>>();
        
        services.AddTransient<IBaseFindByIdRepository<UserDto>, BaseFindByIdRepository<UserDto, DbUser>>();
        services.AddTransient<IBaseFindByIdService<User>, BaseFindByIdService<User, UserDto>>();
    }
    
    private static void RegisterConfigurationDependencies(IServiceCollection services)
    {
        services.AddTransient<IConfigurationReadRepository, ConfigurationReadRepository>();
        services.AddTransient<IConfigurationReadService, ConfigurationReadService>();
        
        services.AddTransient<IBaseCreateRepository<ConfigurationDto>, BaseCreateRepository<ConfigurationDto, DbConfiguration>>();
        services.AddTransient<IBaseCreateService<Configuration>, BaseCreateService<Configuration, ConfigurationDto>>();
        
        services.AddTransient<IBaseUpdateRepository<ConfigurationDto>, BaseUpdateRepository<ConfigurationDto, DbConfiguration>>();
        services.AddTransient<IBaseUpdateService<Configuration>, BaseUpdateService<Configuration, ConfigurationDto>>();
        
        services.AddTransient<IBaseDeleteRepository<ConfigurationDto>, BaseDeleteRepository<ConfigurationDto, DbConfiguration>>();
        services.AddTransient<IBaseDeleteService<Configuration>, BaseDeleteService<Configuration, ConfigurationDto>>();
        
        services.AddTransient<IBaseFindByIdRepository<ConfigurationDto>, BaseFindByIdRepository<ConfigurationDto, DbConfiguration>>();
        services.AddTransient<IBaseFindByIdService<Configuration>, BaseFindByIdService<Configuration, ConfigurationDto>>();
    }
    
}