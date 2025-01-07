using AutoMapper;
using BaseTemplate.PAL.UseCases.Users;

namespace BaseTemplate.BLL.UseCases.Users;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
    
}