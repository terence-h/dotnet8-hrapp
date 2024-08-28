namespace dotnet8_practice_razor.client.Models.Department;

public class DepartmentListModel
{
    public required List<DepartmentInfo> Departments { get; set; }

    public class DepartmentInfo
    {
        public required int Id {  get; set; }
        public required string Name { get; set; }
        public required List<EmployeeInfo> Employees { get; set; }
        public int EmployeeCount { get; set; }
    }

    public class EmployeeInfo
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Salary { get; set; }
        public required int Age { get; set; }
        public required string Gender { get; set; }
    }
}