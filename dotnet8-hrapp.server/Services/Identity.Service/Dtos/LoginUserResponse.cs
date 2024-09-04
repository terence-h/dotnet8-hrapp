namespace Identity.Service.Dtos;

public class LoginUserResponse
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
