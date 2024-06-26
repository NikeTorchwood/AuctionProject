using AutoMapper;
using Domain.Entities;
using Services.Contracts.Users;

namespace Services.Implementations.Mapping;
public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<CreateUserDto, User>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(
                    src => Guid.NewGuid()));
        CreateMap<User, ReadUserDto>();
    }
}

