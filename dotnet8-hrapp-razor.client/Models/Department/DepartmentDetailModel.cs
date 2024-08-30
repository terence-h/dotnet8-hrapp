using System.ComponentModel;

namespace dotnet8_hrapp_razor.client.Models.Department;

public class DepartmentDetailModel
{
    [DisplayName("Department ID")]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required List<EmployeeInfo> Employees { get; set; } = [];
    [DisplayName("Employee Count")]
    public int EmployeeCount { get; set; }
    public double TotalSalary { get; set; }
    public double AverageSalary { get; set; }

    public class EmployeeInfo
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required double Salary { get; set; }
    }
}
