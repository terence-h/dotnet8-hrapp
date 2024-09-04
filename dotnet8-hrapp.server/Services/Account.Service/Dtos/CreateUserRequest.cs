using System.ComponentModel.DataAnnotations;

namespace Account.Service.Dtos;

public class CreateUserRequest
{
    [MaxLength(100)]
    public required string Username { get ;set; }
    [MaxLength(50)]
    public required string Password{ get; set; }
}
