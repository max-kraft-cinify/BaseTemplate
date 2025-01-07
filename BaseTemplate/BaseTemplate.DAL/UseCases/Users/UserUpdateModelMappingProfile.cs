using AutoMapper;
using BaseTemplate.BLL.UseCases.Users;

namespace BaseTemplate.DAL.UseCases.Users;

public class UserUpdateModelDtoMappingProfile: Profile
{
    public UserUpdateModelDtoMappingProfile()
    {
        CreateMap<UserUpdateModelDto, DbUser>().ReverseMap();
    }
    
}