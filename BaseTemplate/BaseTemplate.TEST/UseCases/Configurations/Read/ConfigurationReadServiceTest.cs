using System.Collections.Generic;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations.Read;
using BaseTemplate.TEST.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BaseTemplate.TEST.UseCases.Configurations.Read;

[TestFixture]
public class ConfigurationReadServiceTest
{
    private IConfigurationReadService _configurationReadService;

    [SetUp]
    public void Setup()
    {
        var mockedConfigurationReadRepository = new Mock<IConfigurationReadRepository>();
        mockedConfigurationReadRepository.Setup(x => x.Read()).Returns(() => null);
        
        IConfiguration configurationMock = new ConfigurationBuilder()
            .AddInMemoryCollection(new List<KeyValuePair<string, string>>
            {
            })
            .Build();
        
        _configurationReadService = new ConfigurationReadService(mockedConfigurationReadRepository.Object, configurationMock, AutoMapperGenerator.CreateAutoMapper());
    }

    [Test]
    public void ShouldReturnInstanceOfConfiguration()
    {
        var actual = _configurationReadService.Read();
        ClassicAssert.IsInstanceOf<Configuration>(actual);
    }
        
    [Test]
    public void ShouldReturnNotNullWhenRepositoryReturnsNull()
    {
        var actual = _configurationReadService.Read();
        ClassicAssert.IsNotNull(actual);
    }
        
    [Test]
    public void ShouldReturnDefaultConfigurationWhenRepositoryReturnsNullWithExpectedServiceUrl()
    {
        var expectedServiceUrl = "https://127.0.0.1:4001/";
        var actual = _configurationReadService.Read();
        ClassicAssert.AreEqual(expectedServiceUrl, actual.ServiceUrl);
    }
}