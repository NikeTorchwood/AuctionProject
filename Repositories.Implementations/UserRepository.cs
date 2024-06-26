using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;

namespace Repositories.Implementations;

public class UserRepository(DatabaseContext context) : Repository<User, Guid>(context), IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _entitySet.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _entitySet.FirstOrDefaultAsync(u => u.Email == email);
    }
}

