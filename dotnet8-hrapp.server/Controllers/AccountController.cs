using System.Security.Cryptography;
using System.Text;
using Account.Service.Dtos;
using Account.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet8_hrapp.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ITokenService tokenService) : ControllerBase
{
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<LoginUserResponse>> Register(CreateUserRequest request)
    {
        using var hmac = new HMACSHA512();

        var user = new Account.Service.Entities.User
        {
            UserName = request.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)).ToString(),
        };

        return new LoginUserResponse
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request)
    {
        // find user in repository first
        var user = new Account.Service.Entities.User {
            UserName = "test",
        };

        using var hmac = new HMACSHA512();

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("enter_password_here"));

        for (int i = 0; i < computedHash.Length; i++)
        {
            // if (computedHash[i] != User.PasswordHash[i])
            if (i == 2)
                return Unauthorized("Invalid password");
        }
 
        return new LoginUserResponse
        {
            Username = request.Username,
            Token = await tokenService.CreateToken(user)
        };
    }
}