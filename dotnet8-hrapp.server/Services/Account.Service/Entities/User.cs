using Microsoft.AspNetCore.Identity;

namespace Account.Service.Entities;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = [];
}