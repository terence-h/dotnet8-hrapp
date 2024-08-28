using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Department.Service.Entities;

public record class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmpId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string EmpName { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public required double EmpSalary { get; set; }

    [Required]
    [MaxLength(20)]
    public required string EmpGender { get; set; }

    [Required]
    public required int EmpAge { get; set; }

    [Required]
    public required int EmpContactCountryCode { get; set; }

    [Required]
    public required int EmpContactNo { get; set; }

    [Required]
    [ForeignKey("FK_EMPLOYEE_DEPARTMENT")]
    public required int DepartmentId { get; set; }

    [Required]
    public required Address Address { get; set; }
}