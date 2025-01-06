using System;
using System.Collections.Generic;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.MAIN.Core;
using BaseTemplate.PAL.UseCases.Configurations.Read;
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
    public void ShouldReturnNotNull(Type registeredComponentType)
    {
        InjectorConfiguration.RegisterComponents(_services);
        var actualServiceProvider = _services.BuildServiceProvider();
        ClassicAssert.IsNotNull(actualServiceProvider.GetService(registeredComponentType));
    }
}