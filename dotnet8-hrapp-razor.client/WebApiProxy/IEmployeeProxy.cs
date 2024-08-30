using Employee.Service.Dtos;
using Refit;

namespace dotnet8_hrapp_razor.client.WebApiProxy;

public interface IEmployeeProxy
{
    [Get("/api/Employee")]
    Task<List<SearchEmployeesResponse>> SearchEmployeesAsync();

    [Get("/api/Employee/{employeeId}")]
    Task<DetailEmployeeResponse> GetEmployeeAsync(int employeeId);

    [Post("/api/Employee")]
    Task<int> CreateEmployeeAsync(CreateEmployeeRequest request);

    [Put("/api/Employee/{employeeId}")]
    Task<int> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest employee);

    [Delete("/api/Employee/{employeeId}")]
    Task<int> DeleteEmployeeAsync(int employeeId);
}