using Department.Service.Dtos;
using Refit;

namespace dotnet8_hrapp_razor.client.WebApiProxy;

public interface IDepartmentProxy
{
    [Get("/api/Department")]
    Task<List<SearchDepartmentsResponse>> SearchDepartmentsAsync();

    [Get("/api/Department/{departmentId}")]
    Task<DetailDepartmentResponse> GetDepartmentAsync(int departmentId);

    [Post("/api/Department")]
    Task<int> CreateDepartmentAsync(CreateDepartmentRequest request);
    [Put("/api/Department/{departmentId}")]
    Task<int> UpdateDepartmentAsync(int departmentId, UpdateDepartmentRequest request);

    [Delete("/api/Department/{departmentId}")]
    Task<int> DeleteDepartmentAsync(int departmentId);
}