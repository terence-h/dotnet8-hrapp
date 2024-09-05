using Account.Service.Dtos;
using Account.Service.Entities;
using Account.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet8_hrapp.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ITokenService tokenService, UserManager<User> userManager, IMapper mapper) : ControllerBase
{
    [HttpPost("register")] // api/account/register
    public async Task<ActionResult<LoginUserResponse>> Register(CreateUserRequest request)
    {
        if (await UserExists(request.Username))
            return BadRequest("Username already exists!");

        var user = mapper.Map<User>(request);

        user.UserName = request.Username.ToLower();

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return new LoginUserResponse
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == request.Username.ToUpper());

        if (user == null || user.UserName == null)
            return Unauthorized("Username does not exist");

        bool correctPassword = await userManager.CheckPasswordAsync(user, request.Password);

        if (!correctPassword)
            return Unauthorized("Password does not match username");

        return new LoginUserResponse {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user)
        };
    }

    private async Task<bool> UserExists(string userName)
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == userName.ToUpper());
    }
}