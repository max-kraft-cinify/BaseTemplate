using AutoMapper;
using BaseTemplate.PAL.UseCases.Configurations;

namespace BaseTemplate.BLL.UseCases.Configurations;

public class ConfigurationMappingProfile: Profile
{
    public ConfigurationMappingProfile()
    {
        CreateMap<Configuration, ConfigurationDto>().ReverseMap();
    }
}