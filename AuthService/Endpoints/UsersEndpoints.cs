using AuthService.Api.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Users;

namespace AuthService.Api.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);
            app.MapGet("getUsers", GetUsers).RequireAuthorization(); 
            return app;
        }

        private static async Task<IResult> GetUsers(IUserService userService)
        {
            var users = await userService.GetAllUsers();
            return Results.Ok(users);
        }

        private static async Task<IResult> Login(
            [FromBody] LoginUserModel loginUserModel,
            IMapper mapper,
            IUserService userService,
            HttpContext context)
        {
            try
            {
                var token = await userService.Login(mapper.Map<LoginUserDto>(loginUserModel));
                context.Response.Cookies.Append("secretCookie", token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Results.Ok();
        }

        private static async Task<IResult> Register(
            [FromBody] RegisterUserModel registerUserModel,
            IMapper mapper,
            IUserService userService)
        {
            try
            {
                await userService.Register(mapper.Map<CreateUserDto>(registerUserModel));
            }
            catch (Exception e)
            {
                //Сейчас идет возврат 500 status code, но мне кажется должна быть 403 status code
                Console.WriteLine(e);
                throw;
            }

            return Results.Ok();
        }
    }
}
