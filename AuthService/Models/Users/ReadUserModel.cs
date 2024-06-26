namespace AuthService.Api.Models.Users;

public class ReadUserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

}

