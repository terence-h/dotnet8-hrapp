using Account.Service.Dtos;
using Account.Service.Entities;
using Account.Service.Interfaces;
using AutoMapper;
using Employee.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet8_hrapp.server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminController(ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager, IEmployeeService employeeService, IMapper mapper) : ControllerBase
{
    [Authorize(Policy = "RequireAdmin")]
    [HttpGet("user/users")]
    public async Task<ActionResult> GetUsers()
    {
        var users = await userManager.Users
        .OrderBy(u => u.Id)
        .Select(u => new
        {
            u.Id,
            Username = u.UserName,
            Roles = u.UserRoles.Select(r => r.Role.Name).ToList(),
            u.EmployeeId,
            u.IsDisabled
        })
        .ToListAsync();

        return Ok(users);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpGet("user/{userId}")] // api/admin/user/{userId}
    public async Task<ActionResult> GetUser(int userId)
    {
        var user = await userManager.Users
        .Select(u => new
        {
            u.Id,
            Username = u.UserName,
            Roles = u.UserRoles.Select(r => r.Role.Name).ToList(),
            u.EmployeeId,
            u.IsDisabled
        }).FirstOrDefaultAsync(u => u.Id == userId);

        return Ok(user);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost("register")] // api/admin/register
    public async Task<ActionResult<LoginUserResponse>> Register(CreateUserRequest request)
    {
        if (await UserExists(request.Username))
            return BadRequest(new { Message = "Username already exists" });

        var user = mapper.Map<User>(request);
        user.UserName = request.Username.ToLower();

        int employeeId = await employeeService.CreateEmployeeAsync(request.Employee);
        user.EmployeeId = employeeId;

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await userManager.AddToRoleAsync(user, "User");

        return new LoginUserResponse
        {
            Username = user.UserName,
            Token = await tokenService.CreateToken(user),
        };
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost("user/enableDisableAccount")] // api/admin/enableDisableAccount
    public async Task<ActionResult> EnableDisableAccount(EnableDisableAccountRequest request)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user == null)
            return BadRequest(new { Message = "Username not found" });

        user.IsDisabled = request.IsDisable;
        await userManager.UpdateAsync(user);

        return Ok(request.UserId);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpGet("user/roles")]
    public async Task<ActionResult> GetRoles()
    {
        var roles = await roleManager.Roles.Select(r => new
        {
            r.Id,
            r.Name
        }).ToListAsync();

        return Ok(roles);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPut("user/editUser/{id}")] // api/admin/user/editUser
    public async Task<ActionResult> EditUser(int id, UpdateUserRequest request)
    {
        if (request.Roles.Length == 0)
            return BadRequest(new { Message = "You must select at least one role" });

        var user = await userManager.FindByNameAsync(request.Username);

        if (user == null)
            return BadRequest(new { Message = "Username not found" });

        if (request.CurrentPassword.Length > 0 && request.NewPassword.Length > 0)
        {
            if ((await userManager.CheckPasswordAsync(user, request.CurrentPassword)) == false)
                return BadRequest(new { Message = "Current password does not match"});

            await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        }

        var currentRoles = await userManager.GetRolesAsync(user);

        var result = await userManager.AddToRolesAsync(user, request.Roles.Except(currentRoles));

        if (!result.Succeeded)
            return BadRequest(new { Message = "Failed to add roles" });

        result = await userManager.RemoveFromRolesAsync(user, currentRoles.Except(request.Roles));

        if (!result.Succeeded)
            return BadRequest(new { Message = "Failed to remove roles" });

        return Ok(user.Id);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpGet("user/checkUsername")] // api/admin/user/checkUsername?userName={userName}
    public async Task<bool> UserExists(string userName)
    {
        return await userManager.Users.AnyAsync(x => x.NormalizedUserName == userName.ToUpper());
    }
}