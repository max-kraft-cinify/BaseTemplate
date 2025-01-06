using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.DAL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.TEST.Core;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BaseTemplate.TEST.UseCases.Configurations;

[TestFixture]
public class ConfigurationDtoMappingProfileTest
{
    private DbConfiguration _dbConfigurationToTransform;
    private ConfigurationDto _configurationDtoToTransform;
    private IMapper _mapper;

    [SetUp]
    public void Setup()
    {
        _dbConfigurationToTransform = new DbConfiguration
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
        var actual = _mapper.Map<ConfigurationDto>(_dbConfigurationToTransform);
        
        ClassicAssert.IsInstanceOf<ConfigurationDto>(actual);
    }
    
    [Test]
    public void ShouldReturnExpectedInstanceOfDbConfiguration()
    {
        var actual = _mapper.Map<DbConfiguration>(_configurationDtoToTransform);
        
        ClassicAssert.IsInstanceOf<DbConfiguration>(actual);
    }

    [Test]
    public void ShouldReturnExpectedServiceUrlForConfigurationDto()
    {
        var expected = _dbConfigurationToTransform.ServiceUrl;
        var actual = _mapper.Map<ConfigurationDto>(_dbConfigurationToTransform);
        ClassicAssert.AreEqual(expected, actual.ServiceUrl);
    }
    
    [Test]
    public void ShouldReturnExpectedServiceUrlForConfiguration()
    {
        var expected = _configurationDtoToTransform.ServiceUrl;
        var actual = _mapper.Map<DbConfiguration>(_configurationDtoToTransform);
        ClassicAssert.AreEqual(expected, actual.ServiceUrl);
    }
}