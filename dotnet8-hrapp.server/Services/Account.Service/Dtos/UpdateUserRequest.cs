namespace Account.Service.Dtos;

public class UpdateUserRequest
{
    public required int Id { get; set; }
    public required string Username { get; set; }
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
    public required string[] Roles { get; set; } = [];
}