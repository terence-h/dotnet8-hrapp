using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Service.Dtos;

public class UpdateEmployeeRequest
{
    public required int EmpId { get; set; }
    [Required]
    public required string EmpName { get; set; }
    [Required]
    public required double EmpSalary { get; set; }
    [Required]
    public required string EmpGender { get; set; }
    [Required]
    public required int EmpAge { get; set; }
    [Required]
    public required int EmpContactCountryCode { get; set; }
    [Required]
    public required int EmpContactNo { get; set; }
    [Required]
    public required int EmpDepartmentId { get; set; }
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
