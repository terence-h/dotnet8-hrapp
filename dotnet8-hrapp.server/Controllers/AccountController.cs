using Account.Service.Dtos;
using Account.Service.Entities;
using Account.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet8_hrapp.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ITokenService tokenService, UserManager<User> userManager) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")] // api/account/login
    public async Task<ActionResult<LoginUserResponse>> Login(LoginUserRequest request)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == request.Username.ToUpper());

        if (user == null || user.UserName == null)
            return Unauthorized(new { Message = "Invalid username/password" });

        if (user.IsDisabled)
            return Unauthorized(new { Message = "User account is disabled. Please contact system administrator."} );

        bool correctPassword = await userManager.CheckPasswordAsync(user, request.Password);

        if (!correctPassword)
            return Unauthorized(new { Message = "Invalid username/password" });

        return new LoginUserResponse {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user),
        };
    }
}