using System.ComponentModel;

namespace dotnet8_hrapp_razor.client.Models.Department;

public class DepartmentCreateModel
{
    [DisplayName("Name (required)")]
    public required string Name { get; set; }
}
