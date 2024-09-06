using Account.Service.Dtos;
using Account.Service.Entities;
using Account.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet8_hrapp.server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminController(ITokenService tokenService, UserManager<User> userManager, IMapper mapper) : ControllerBase
{
    [Authorize(Policy = "RequireAdmin")]
    [HttpPost("register")] // api/admin/register
    public async Task<ActionResult<LoginUserResponse>> Register(CreateUserRequest request)
    {
        if (await UserExists(request.Username))
            return BadRequest("Username already exists!");

        var user = mapper.Map<User>(request);

        user.UserName = request.Username.ToLower();

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await userManager.AddToRoleAsync(user, "User");

        return new LoginUserResponse
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user)
        };
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost("editRoles")] // api/admin/editRoles
    public async Task<ActionResult<IList<string>>> EditRoles(UpdateUserRolesRequest request)
    {
        if (request.Roles.Length == 0)
            return BadRequest("You must select at least one role");

        var user = await userManager.FindByNameAsync(request.Username);

        if (user == null)
            return BadRequest("Username not found");

        var currentRoles = await userManager.GetRolesAsync(user);

        var result = await userManager.AddToRolesAsync(user, request.Roles.Except(currentRoles));

        if (!result.Succeeded)
            return BadRequest("Failed to add roles");

        result = await userManager.RemoveFromRolesAsync(user, currentRoles.Except(request.Roles));

        if (!result.Succeeded)
            return BadRequest("Failed to remove roles");

        return Ok(await userManager.GetRolesAsync(user));
    }

    private async Task<bool> UserExists(string userName)
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == userName.ToUpper());
    }
}
