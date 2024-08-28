using System.ComponentModel;

namespace dotnet8_practice_razor.client.Models.Department;

public class DepartmentEditModel
{
    public int Id { get; set; }
    [DisplayName("Name (required)")]
    public required string Name { get; set; }
}
