using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;

namespace BaseTemplate.DAL.UseCases.Configurations;

public class ConfigurationDtoMappingProfile : Profile
    {
    public ConfigurationDtoMappingProfile()
    {
        CreateMap<ConfigurationDto, DbConfiguration>().ReverseMap();
    }
}