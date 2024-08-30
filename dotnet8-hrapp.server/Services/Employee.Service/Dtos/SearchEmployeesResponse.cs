namespace Employee.Service.Dtos;

public class SearchEmployeesResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required double Salary { get; set; }
    public required int DepartmentId { get; set; }
    public required string DepartmentName { get; set; }
}