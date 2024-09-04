using Microsoft.AspNetCore.Identity;

namespace Identity.Service.Entities;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = [];
}