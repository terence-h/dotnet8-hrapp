using System;

namespace Account.Service.Dtos;

public class EnableDisableAccountRequest
{
    public required int UserId { get; set; }
    public required bool IsDisable { get; set; }
}
