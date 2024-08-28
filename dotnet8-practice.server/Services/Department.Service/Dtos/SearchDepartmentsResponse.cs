namespace Department.Service.Dtos;

public class SearchDepartmentsResponse
{
    public required int DepartmentId { get; set; }
    public required string DepartmentName { get; set; }
    public required List<Employee> Employees { get; set; }

    public class Employee
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Salary { get; set; }
        public required string Gender { get; set; }
        public required int Age { get; set; }
    }
}