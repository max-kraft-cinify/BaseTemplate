using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.DAL.UseCases.Configurations;

namespace BaseTemplate.TEST.Core;

public class AutoMapperGenerator
{
    public static IMapper CreateAutoMapper()
    {
        return new Mapper(new MapperConfiguration(mapperConfigurationExpression =>
        {
            mapperConfigurationExpression.AllowNullCollections = false;
            
            mapperConfigurationExpression.AddProfile<ConfigurationMappingProfile>();
            mapperConfigurationExpression.AddProfile<ConfigurationDtoMappingProfile>();
        }));
    }
}