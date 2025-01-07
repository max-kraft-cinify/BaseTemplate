using AutoMapper;
using BaseTemplate.BLL.UseCases.Configurations;
using BaseTemplate.BLL.UseCases.Users;
using BaseTemplate.DAL.UseCases.Configurations;
using BaseTemplate.DAL.UseCases.Users;

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
            mapperConfigurationExpression.AddProfile<UserMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserDtoMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserUpdateModelMappingProfile>();
            mapperConfigurationExpression.AddProfile<UserUpdateModelDtoMappingProfile>();
        }));
    }
}