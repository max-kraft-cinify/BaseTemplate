using System.IO.Abstractions;
using BaseTemplate.BLL.UseCases.Configurations.Read;
using BaseTemplate.DAL.UseCases.Configurations.Read;
using BaseTemplate.TEST.Core;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BaseTemplate.TEST.UseCases.Configurations.Read;

[TestFixture]
public class ConfigurationReadRepositoryTest
{
    private IConfigurationReadRepository _configurationReadRepository;
    private bool _doesFileExists;
    private string _fileContent;
    [SetUp]
    public void Setup()
    {
        _doesFileExists = false;
        _fileContent = "";
        var mockedFileSystem = new Mock<IFileSystem>();
        mockedFileSystem.Setup(x => x.File.Exists("configuration.json")).Returns(() => _doesFileExists);
        mockedFileSystem.Setup(x => x.File.ReadAllText("configuration.json")).Returns(() => _fileContent);
        mockedFileSystem.Setup(x => x.Path.GetDirectoryName(It.IsAny<string>())).Returns(() => "");
        mockedFileSystem.Setup(x => x.Path.Combine(It.IsAny<string>(), "configuration.json")).Returns(() => "configuration.json");
            
        _configurationReadRepository = new ConfigurationReadRepository(mockedFileSystem.Object, AutoMapperGenerator.CreateAutoMapper());
    }
        
    [Test]
    public void ShouldReturnNullWhenFileNotExists()
    {
        var actual = _configurationReadRepository.Read();
        ClassicAssert.IsNull(actual);
    }
        
    [Test]
    public void ShouldReturnNullWhenFileIsEmpty()
    {
        _doesFileExists = true;
        var actual = _configurationReadRepository.Read();
        ClassicAssert.IsNull(actual);
    }
        
    [Test]
    public void ShouldReturnConfigurationWithExpectedUrl()
    {
        var expectedServiceUrl = "http://localhost:4000/";
        _doesFileExists = true;
        _fileContent = "{\"ServiceUrl\":\"http://localhost:4000/\"}";
        var actual = _configurationReadRepository.Read();
        ClassicAssert.AreEqual(expectedServiceUrl, actual.ServiceUrl);
    }
}