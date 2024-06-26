using AuthService.Api.Models.Users;
using AutoMapper;
using Services.Abstractions;
using Services.Contracts.Users;

namespace AuthService.Api.Mapping;

public class UsersMappingProfile : Profile
{
    private readonly IPasswordHasher _passwordHasher;

    public UsersMappingProfile(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;

        CreateMap<RegisterUserModel, CreateUserDto>()
            .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(
                    src => _passwordHasher.GeneratePassword(src.Password)));
        CreateMap<ReadUserDto, ReadUserModel>();
        CreateMap<LoginUserModel, LoginUserDto>();
    }
}

