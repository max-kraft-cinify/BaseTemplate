using System;
using System.Collections.Generic;
using BaseTemplate.BLL.Core.Create;
using BaseTemplate.BLL.Core.Delete;
using BaseTemplate.BLL.Core.FindById;
using BaseTemplate.BLL.Core.Update;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.BLL.UseCases.Users;
using BaseTemplate.MAIN.Core;
using BaseTemplate.PAL.Core.Create;
using BaseTemplate.PAL.Core.Delete;
using BaseTemplate.PAL.Core.FindById;
using BaseTemplate.PAL.Core.Update;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations.Read;
using BaseTemplate.PAL.UseCases.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BaseTemplate.TEST.Core;

[TestFixture]
public class InjectorConfigurationTest
{
    private IServiceCollection _services;

    [SetUp]
    public void Setup()
    {
        _services = new ServiceCollection();
        _services.Add(ServiceDescriptor.Describe(typeof(ILogger<>), typeof(Logger<>), ServiceLifetime.Scoped));
        _services.AddLogging(loggerOptions =>
        {
            loggerOptions.ClearProviders();
            loggerOptions.AddConsole();
            loggerOptions.AddDebug();
        });
        IConfiguration configurationMock = new ConfigurationBuilder()
            .AddInMemoryCollection(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Webserver:EndPoints:Http:Url", "https://*:2018"),
            })
            .Build();
        _services.AddSingleton(_ => configurationMock);
    }


    [Test]
    public void ShouldReturnNotEmpty()
    {
        InjectorConfiguration.RegisterComponents(_services);
        ClassicAssert.IsNotEmpty(_services);
    }

    [Test]
    [TestCase(typeof(IConfigurationReadService))]
    [TestCase(typeof(IConfigurationReadRepository))]
    
    [TestCase(typeof(IBaseCreateRepository<ConfigurationDto>))]
    [TestCase(typeof(IBaseFindByIdRepository<ConfigurationDto>))]
    [TestCase(typeof(IBaseUpdateRepository<ConfigurationDto>))]
    [TestCase(typeof(IBaseDeleteRepository<ConfigurationDto>))]
    [TestCase(typeof(IBaseCreateService<Configuration>))]
    [TestCase(typeof(IBaseFindByIdService<Configuration>))]
    [TestCase(typeof(IBaseUpdateService<Configuration>))]
    [TestCase(typeof(IBaseDeleteService<Configuration>))]
    
    [TestCase(typeof(IBaseCreateRepository<UserDto>))]
    [TestCase(typeof(IBaseFindByIdRepository<UserDto>))]
    [TestCase(typeof(IBaseUpdateRepository<UserUpdateModelDto>))]
    [TestCase(typeof(IBaseDeleteRepository<UserDto>))]
    [TestCase(typeof(IBaseCreateService<User>))]
    [TestCase(typeof(IBaseFindByIdService<User>))]
    [TestCase(typeof(IBaseUpdateService<UserUpdateModel>))]
    [TestCase(typeof(IBaseDeleteService<User>))]
    public void ShouldReturnNotNull(Type registeredComponentType)
    {
        InjectorConfiguration.RegisterComponents(_services);
        var actualServiceProvider = _services.BuildServiceProvider();
        ClassicAssert.IsNotNull(actualServiceProvider.GetService(registeredComponentType));
    }
}