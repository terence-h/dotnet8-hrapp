using Employee.Service.Dtos;
using System.ComponentModel;

namespace dotnet8_practice_razor.client.Models.Employee;

public class EmployeeDetailModel
{
    [DisplayName("Employee ID")]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required double Salary { get; set; }
    public required int Age { get; set; }
    public required string Gender { get; set; }
    public required int ContactCountryCode { get; set; }
    [DisplayName("Contact No.")]
    public required int ContactNo { get; set; }
    public required int DepartmentId { get; set; }
    [DisplayName("Department")]
    public required string DepartmentName { get; set; }
    public required AddressInfo Address { get; set; }

    public class AddressInfo
    {
        [DisplayName("Address Line 1")]
        public required string Line1 { get; set; }
        [DisplayName("Address Line 2")]
        public string? Line2 { get; set; }
        [DisplayName("Unit No.")]
        public string? UnitNo { get; set; }
        [DisplayName("Postal Code")]
        public required int PostalCode { get; set; }
        public required string Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}