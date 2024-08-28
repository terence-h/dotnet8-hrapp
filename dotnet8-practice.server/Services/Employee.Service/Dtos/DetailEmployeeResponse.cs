namespace Employee.Service.Dtos;

public class DetailEmployeeResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required double Salary { get; set; }
    public required string Gender { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required int ContactCountryCode { get; set; }
    public required int ContactNo { get; set; }
    public required int DepartmentId { get; set; }
    public required string DepartmentName { get; set; }
    public required Address EmpAddress { get; set; }

    public class Address
    {
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? UnitNo { get; set; }
        public required int PostalCode { get; set; }
        public required string Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}