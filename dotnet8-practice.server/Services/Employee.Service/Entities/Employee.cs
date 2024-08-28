using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Service.Entities;

public record class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public required double Salary { get; set; }

    [Required]
    [MaxLength(20)]
    public required string Gender { get; set; }

    [Required]
    public required DateTime DateOfBirth { get; set; }

    [Required]
    public required int ContactCountryCode { get; set; }

    [Required]
    public required int ContactNo { get; set; }

    [Required]
    [ForeignKey(nameof(Department))]
    public required int DepartmentId { get; set; }

    public required Department Department { get; init; }

    [Required]
    public required Address Address { get; set; }
}