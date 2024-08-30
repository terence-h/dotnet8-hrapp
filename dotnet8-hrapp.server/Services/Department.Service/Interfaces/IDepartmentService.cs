using Department.Service.Dtos;

namespace Department.Service.Interfaces;

public interface IDepartmentService
{
    Task<List<SearchDepartmentsResponse>> SearchDepartmentsAsync();
    Task<DetailDepartmentResponse> GetDepartmentAsync(int departmentId);
    Task<int> CreateDepartmentAsync(CreateDepartmentRequest department);
    Task<int> UpdateDepartmentAsync(UpdateDepartmentRequest request);
    Task<int> DeleteDepartmentAsync(int departmentId);
}
