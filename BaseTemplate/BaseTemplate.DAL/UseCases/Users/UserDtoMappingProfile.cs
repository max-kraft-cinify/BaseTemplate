using AutoMapper;
using BaseTemplate.BLL.UseCases.Users;

namespace BaseTemplate.DAL.UseCases.Users;

public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<UserDto, DbUser>()
            .ForMember(dbUser => dbUser.Login, memberOptions => memberOptions.Ignore())
            .ForMember(dbUser => dbUser.Password, memberOptions => memberOptions.Ignore())
            .ReverseMap();
    }
}