using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Service.Dtos;

public class UpdateEmployeeRequest
{
    public required int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required double Salary { get; set; }
    [Required]
    public required string Gender { get; set; }
    [Required]
    public required DateTime DateOfBirth { get; set; }
    [Required]
    public required int ContactCountryCode { get; set; }
    [Required]
    public required int ContactNo { get; set; }
    [Required]
    public required int DepartmentId { get; set; }
    [Required]
    public required Address EmpAddress { get; set; }

    public class Address
    {
        [Required]
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? UnitNo { get; set; }
        [Required]
        public required int PostalCode { get; set; }
        [Required]
        public required string Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
