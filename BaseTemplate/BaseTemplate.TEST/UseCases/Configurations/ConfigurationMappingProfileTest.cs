using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.TEST.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BaseTemplate.TEST.UseCases.Configurations;

[TestFixture]
public class ConfigurationMappingProfileTest
{
    private Configuration _configurationToTransform;
    private ConfigurationDto _configurationDtoToTransform;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _configurationToTransform = new Configuration
        {
            ServiceUrl = "https://localhost:5001",
        };

        _configurationDtoToTransform = new ConfigurationDto
        {
            ServiceUrl = "https://localhost:5001",
        };
        _mapper = AutoMapperGenerator.CreateAutoMapper();
    }

    [Test]
    public void ShouldReturnExpectedInstanceOfConfigurationDto()
    {
        var actual = _mapper.Map<ConfigurationDto>(_configurationToTransform);
        
        ClassicAssert.IsInstanceOf<ConfigurationDto>(actual);
    }
    
    [Test]
    public void ShouldReturnExpectedInstanceOfConfiguration()
    {
        var actual = _mapper.Map<Configuration>(_configurationDtoToTransform);
        
        ClassicAssert.IsInstanceOf<Configuration>(actual);
    }

    [Test]
    public void ShouldReturnExpectedServiceUrlForConfigurationDto()
    {
        var expected = _configurationToTransform.ServiceUrl;
        var actual = _mapper.Map<ConfigurationDto>(_configurationToTransform);
        ClassicAssert.AreEqual(expected, actual.ServiceUrl);
    }
    
    [Test]
    public void ShouldReturnExpectedServiceUrlForConfiguration()
    {
        var expected = _configurationDtoToTransform.ServiceUrl;
        var actual = _mapper.Map<Configuration>(_configurationDtoToTransform);
        ClassicAssert.AreEqual(expected, actual.ServiceUrl);
    }
}