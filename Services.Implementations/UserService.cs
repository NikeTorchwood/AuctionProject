using AutoMapper;
using Domain.Entities;
using Repositories.Abstractions;
using Services.Abstractions;
using Services.Contracts.Users;

namespace Services.Implementations;
public class UserService(IUserRepository repository, IMapper mapper, IPasswordHasher hasher, IJwtProvider jwrProvider) : IUserService
{
    public async Task Register(CreateUserDto createUserDto)
    {
        if (createUserDto == null)
        {
            throw new ArgumentNullException(nameof(createUserDto));
        }

        var username = repository.GetUserByUsernameAsync(createUserDto.Username).Result?.Username;
        if (username != null)
        {
            throw new ArgumentException("Username is reserved", nameof(createUserDto.Username));
        }
        var email = repository.GetUserByEmailAsync(createUserDto.Email).Result?.Email;
        if (email != null)
        {
            throw new ArgumentException("Email is reserved", nameof(email));
        }

        await repository.AddAsync(mapper.Map<User>(createUserDto));
        await repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ReadUserDto>> GetAllUsers()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        var users = await repository.GetAllAsync(ct);
        return mapper.Map<IEnumerable<ReadUserDto>>(users);
    }

    public async Task<string> Login(LoginUserDto loginUserModel)
    {
        if (loginUserModel == null)
        {
            throw new ArgumentNullException(nameof(loginUserModel));
        }
        var user = await repository.GetUserByEmailAsync(loginUserModel.Email);
        if (user == null)
        {
            throw new ArgumentException("Invalid username and password pair", nameof(loginUserModel));
        }

        if (!hasher.VerifyPassword(loginUserModel.Password, user.PasswordHash))
        {
            throw new ArgumentException("Invalid username and password pair", nameof(loginUserModel));
        }

        return await jwrProvider.Generate(user);
    }
}