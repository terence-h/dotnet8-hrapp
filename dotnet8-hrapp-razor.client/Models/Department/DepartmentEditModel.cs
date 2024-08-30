using System.ComponentModel;

namespace dotnet8_hrapp_razor.client.Models.Department;

public class DepartmentEditModel
{
    public int Id { get; set; }
    [DisplayName("Name (required)")]
    public required string Name { get; set; }
}
