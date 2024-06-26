using Services.Contracts.Users;

namespace Services.Abstractions;

public interface IUserService
{
    Task Register(CreateUserDto createUserDto);
    Task<IEnumerable<ReadUserDto>> GetAllUsers();
    Task<string> Login(LoginUserDto loginUserModel);
}