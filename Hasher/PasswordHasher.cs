using Services.Abstractions;

namespace Infrastructure.Hasher;
public class PasswordHasher: IPasswordHasher
{
    public string GeneratePassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public bool VerifyPassword(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
