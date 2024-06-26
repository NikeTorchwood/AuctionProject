namespace Services.Contracts.Users;

public class ReadUserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

}

