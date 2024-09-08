using System.ComponentModel.DataAnnotations;
using Employee.Service.Dtos;

namespace Account.Service.Dtos;

public class CreateUserRequest
{
    [StringLength(24, MinimumLength = 4)]
    public required string Username { get ;set; }
    [StringLength(24, MinimumLength = 8)]
    public required string Password{ get; set; }
    public required CreateEmployeeRequest Employee { get; set;}
}
