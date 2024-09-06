namespace Account.Service.Dtos;

public class UpdateUserRolesRequest
{
    public required string Username { get; set; }
    public required string[] Roles { get; set; } = [];
}