using System.ComponentModel;

namespace dotnet8_practice_razor.client.Models.Employee;

public class EmployeeEditModel
{
    public int Id { get; set; }
    [DisplayName("Name (required)")]
    public string? Name { get; set; }
    [DisplayName("Salary (required)")]
    public double Salary { get; set; }
    [DisplayName("Date of Birth (required)")]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("Gender (required)")]
    public string? Gender { get; set; }
    [DisplayName("Country Code (required)")]
    public int ContactCountryCode { get; set; }
    [DisplayName("Contact No. (required)")]
    public int ContactNo { get; set; }
    [DisplayName("Department (required)")]
    public int DepartmentId { get; set; }
    public AddressInfo? Address { get; set; }

    public class AddressInfo
    {
        [DisplayName("Address Line 1 (required)")]
        public required string Line1 { get; set; }
        [DisplayName("Address Line 2")]
        public string? Line2 { get; set; }
        [DisplayName("Unit No.")]
        public string? UnitNo { get; set; }
        [DisplayName("Postal Code (required)")]
        public required int PostalCode { get; set; }
        [DisplayName("Country (required)")]
        public required string Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }

    public List<KeyValuePair<string, int?>> DepartmentSelectList { get; set; } = [];
}
