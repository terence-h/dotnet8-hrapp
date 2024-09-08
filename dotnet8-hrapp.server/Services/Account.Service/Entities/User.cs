using Microsoft.AspNetCore.Identity;

namespace Account.Service.Entities;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public virtual bool IsDisabled { get; set; }
    public virtual int? EmployeeId { get; set; }
}