﻿namespace AuthService.Api.Models.Users;

public class RegisterUserModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}