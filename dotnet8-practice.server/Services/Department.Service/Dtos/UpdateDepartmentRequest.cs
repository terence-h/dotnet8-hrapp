using System.ComponentModel.DataAnnotations;

namespace Department.Service.Dtos;

public class UpdateDepartmentRequest
{
    public required int DepartmentId { get; set; }
    [Required]
    public required string DepartmentName { get; set; }
}