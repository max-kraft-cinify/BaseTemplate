using AutoMapper;
using BaseTemplate.PAL.UseCases.Configurations;
using BaseTemplate.PAL.UseCases.Configurations.Read;
using Microsoft.Extensions.Configuration;

namespace BaseTemplate.BLL.UseCases.Configurations.Read;

public class ConfigurationReadService: IConfigurationReadService
{
    private readonly IConfigurationReadRepository _configurationReadRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public ConfigurationReadService(IConfigurationReadRepository configurationReadRepository, 
        IConfiguration configuration, IMapper mapper)
    {
        _configurationReadRepository = configurationReadRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public Configuration Read()
    {
        var configurationDto = _configurationReadRepository.Read();
        if (configurationDto == null)
        {
            return GetDefaultConfiguration();
        }
        
        return _mapper.Map<Configuration>(configurationDto);
    }

    private Configuration GetDefaultConfiguration()
    {
        Configuration currentConfiguration;
        var defaultCoreServiceUrlEnvironmentVariable = "DEFAULT_CORE_SERVICE_URL";
        var defaultCoreServiceUrl = "https://127.0.0.1:4001/";
        currentConfiguration = new Configuration
        {
            ServiceUrl = _configuration.GetValue<string>(defaultCoreServiceUrlEnvironmentVariable, defaultCoreServiceUrl)
        };
        return currentConfiguration;
    }
}