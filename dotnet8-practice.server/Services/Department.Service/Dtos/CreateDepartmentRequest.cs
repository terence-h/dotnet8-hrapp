using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Department.Service.Dtos;

public class CreateDepartmentRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int DepartmentId { get; set; }
    [Required]
    public required string DepartmentName { get; set; }
}
