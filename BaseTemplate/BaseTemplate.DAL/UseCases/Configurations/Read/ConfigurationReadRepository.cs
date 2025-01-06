using System.Diagnostics;
using System.IO.Abstractions;
using System.Text.Json;
using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Configurations.Read;

namespace BaseTemplate.DAL.UseCases.Configurations.Read;

public class ConfigurationReadRepository : IConfigurationReadRepository
{
    private const string ConfigurationJsonFile = "configuration.json";
    private readonly IFileSystem _fileSystem;
    private readonly IMapper _mapper;

    public ConfigurationReadRepository(IFileSystem fileSystem, IMapper mapper)
    {
        _fileSystem = fileSystem;
        _mapper = mapper;
    }

    public ConfigurationDto Read()
    {
        var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
        var serviceDirectory = _fileSystem.Path.GetDirectoryName(pathToExe);
        var configurationFilePath = _fileSystem.Path.Combine(serviceDirectory, ConfigurationJsonFile);
        if (!_fileSystem.File.Exists(configurationFilePath))
        {
            return null;
        }

        var jsonContent = _fileSystem.File.ReadAllText(configurationFilePath);
        var dbConfiguration = jsonContent == "" ? null : JsonSerializer.Deserialize<DbConfiguration>(jsonContent);
        return _mapper.Map<ConfigurationDto>(dbConfiguration);

    }
}