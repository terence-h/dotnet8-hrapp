using Microsoft.AspNetCore.Identity;

namespace Account.Service.Entities;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = [];
}