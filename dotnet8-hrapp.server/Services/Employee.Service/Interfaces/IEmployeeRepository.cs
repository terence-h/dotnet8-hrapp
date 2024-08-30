namespace Employee.Service.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Entities.Employee>> SearchEmployeesAsync();
    Task<Entities.Employee> GetEmployeeAsync(int employeeId);
    Task<int> CreateEmployeeAsync(Entities.Employee employee);
    Task<int> UpdateEmployeeAsync(Entities.Employee employee);
    Task<int> DeleteEmployeeAsync(int employeeId);
}
