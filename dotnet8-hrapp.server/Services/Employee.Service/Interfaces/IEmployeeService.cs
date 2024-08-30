using Employee.Service.Dtos;

namespace Employee.Service.Interfaces;

public interface IEmployeeService
{
    Task<List<SearchEmployeesResponse>> SearchEmployeesAsync();
    Task<DetailEmployeeResponse> GetEmployeeAsync(int employeeId);
    Task<int> CreateEmployeeAsync(CreateEmployeeRequest employee);
    Task<int> UpdateEmployeeAsync(UpdateEmployeeRequest employee);
    Task<int> DeleteEmployeeAsync(int employeeId);
}
