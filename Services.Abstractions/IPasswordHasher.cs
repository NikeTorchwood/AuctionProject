namespace Services.Abstractions;
public interface IPasswordHasher
{
    public string GeneratePassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
}

