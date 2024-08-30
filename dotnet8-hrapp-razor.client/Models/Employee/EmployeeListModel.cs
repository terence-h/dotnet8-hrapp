namespace dotnet8_hrapp_razor.client.Models.Employee;

public class EmployeeListModel
{
    public required List<EmployeeInfo> Employees { get; set; }

    public class EmployeeInfo
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Salary { get; set; }
        public required int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
    }
}