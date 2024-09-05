using System.Text.Json;
using Account.Service.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Account.Service.Data;

public class DataSeed
{
    public static async Task SeedDefaultAccountsAndRoles(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        // Already seeded from previous startup
        if (await userManager.Users.AnyAsync())
            return;

        var userData = await File.ReadAllTextAsync("Services/Account.Service/Data/InitialUsers.json");
        var adminData = await File.ReadAllTextAsync("Services/Account.Service/Data/InitialAdmins.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var users = JsonSerializer.Deserialize<List<User>>(userData, options);
        var admins = JsonSerializer.Deserialize<List<User>>(adminData, options);

        if (users == null)
            return;

        List<Role> roles =
        [
            new() { Name = "Admin" },
            new() { Name = "User" },
        ];

        foreach (Role role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        foreach(var user in users)
        {
            await userManager.CreateAsync(user, "Passw0rd!");
            await userManager.AddToRoleAsync(user, "User");
        }

        if (admins == null)
            return;

        foreach(var admin in admins)
        {
            await userManager.CreateAsync(admin, "Passw0rd!");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}