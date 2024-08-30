namespace Department.Service.Interfaces;

public interface IDepartmentRepository
{
    Task<List<Entities.Department>> SearchDepartmentsAsync();
    Task<Entities.Department> GetDepartmentAsync(int departmentId);
    Task<int> CreateDepartmentAsync(Entities.Department department);
    Task<int> UpdateDepartmentAsync(Entities.Department department);
    Task<int> DeleteDepartmentAsync(int departmentId);
}
