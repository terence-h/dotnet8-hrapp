namespace Employee.Service.Dtos;

public class SearchEmployeesResponse
{
    public required int EmpId { get; set; }
    public required string EmpName { get; set; }
    public required double EmpSalary { get; set; }
    public required string EmpGender { get; set; }
    public required int EmpAge { get; set; }
    public required int EmpDepId { get; set; }
    public required string EmpDepName { get; set; }
}