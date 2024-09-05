using System.ComponentModel.DataAnnotations;

namespace Account.Service.Dtos;

public class LoginUserRequest
{
    [StringLength(24, MinimumLength = 4)]
    public required string Username { get; set; }
    [StringLength(24, MinimumLength = 4)]
    public required string Password { get; set; }
}
