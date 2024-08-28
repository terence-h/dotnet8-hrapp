namespace Employee.Service.Dtos;

public class DetailEmployeeResponse
{
    public required int EmpId { get; set; }
    public required string EmpName { get; set; }
    public required double EmpSalary { get; set; }
    public required string EmpGender { get; set; }
    public required int EmpAge { get; set; }
    public required int EmpContactCountryCode { get; set; }
    public required int EmpContactNo { get; set; }
    public required int EmpDepId { get; set; }
    public required string EmpDepName { get; set; }
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