namespace Account.Service.Dtos;

public class LoginUserRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
