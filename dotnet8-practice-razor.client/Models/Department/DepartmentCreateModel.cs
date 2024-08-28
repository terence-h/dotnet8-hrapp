using System.ComponentModel;

namespace dotnet8_practice_razor.client.Models.Department;

public class DepartmentCreateModel
{
    [DisplayName("Name (required)")]
    public required string Name { get; set; }
}
