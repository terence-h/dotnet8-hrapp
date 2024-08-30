using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Department.Service.Entities;

public record class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string DepartmentName { get; set; }

    [Required]
    public required List<Employee> Employees { get; set; }
}
