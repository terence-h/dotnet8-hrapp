using Account.Service.Entities;

namespace Account.Service.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
