using Domain.Entities;

namespace Services.Abstractions;

public interface IJwtProvider
{
    Task<string> Generate(User user);
}