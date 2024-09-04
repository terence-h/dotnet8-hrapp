using Microsoft.AspNetCore.Identity;

namespace Identity.Service.Entities;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = [];
}