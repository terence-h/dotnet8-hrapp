using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Service.Entities;

[ComplexType]
public record class Address
{
    [Required]
    [Column("EMPLOYEE_ADDRESS_LINE_1")]
    public required string Line1 { get; set; }
    [Column("EMPLOYEE_ADDRESS_LINE_2")]
    public string? Line2 { get; set; }
    [Column("EMPLOYEE_ADDRESS_UNIT_NO")]
    public string? UnitNo { get; set; }
    [Required]
    [Column("EMPLOYEE_ADDRESS_POSTAL_CODE")]
    public required int PostalCode { get; set; }
    [Required]
    [Column("EMPLOYEE_ADDRESS_COUNTRY")]
    public required string Country { get; set; }
    [Column("EMPLOYEE_ADDRESS_CITY")]
    public string? City { get; set; }
    [Column("EMPLOYEE_ADDRESS_STATE")]
    public string? State { get; set; }
}