using Domain.Entities;

namespace Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
