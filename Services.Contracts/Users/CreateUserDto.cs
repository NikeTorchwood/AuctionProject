﻿namespace Services.Contracts.Users;

public class CreateUserDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
}

