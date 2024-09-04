using System;
using Identity.Service.Entities;

namespace Identity.Service.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(User user);
}
