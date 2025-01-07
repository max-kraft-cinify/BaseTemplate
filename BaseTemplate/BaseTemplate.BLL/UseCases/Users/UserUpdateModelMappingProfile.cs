using AutoMapper;
using BaseTemplate.PAL.UseCases.Users;

namespace BaseTemplate.BLL.UseCases.Users;

public class UserUpdateModelMappingProfile: Profile
{
    public UserUpdateModelMappingProfile()
    {
        CreateMap<UserUpdateModel, UserUpdateModelDto>().ReverseMap();
    }
    
}