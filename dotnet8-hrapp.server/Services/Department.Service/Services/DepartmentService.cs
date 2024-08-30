using AutoMapper;
using Department.Service.Dtos;
using Department.Service.Interfaces;

namespace Department.Service.Services;

public class DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
{
    public async Task<int> CreateDepartmentAsync(CreateDepartmentRequest department)
    {
        var mappedData = mapper.Map<Entities.Department>(department);
        var result = await departmentRepository.CreateDepartmentAsync(mappedData);

        return result;
    }

    public async Task<int> DeleteDepartmentAsync(int departmentId)
    {
        var result = await departmentRepository.DeleteDepartmentAsync(departmentId);

        return result;
    }

    public async Task<DetailDepartmentResponse> GetDepartmentAsync(int departmentId)
    {
        var result = await departmentRepository.GetDepartmentAsync(departmentId);
        var mappedData = mapper.Map<DetailDepartmentResponse>(result);

        return mappedData;
    }

    public async Task<List<SearchDepartmentsResponse>> SearchDepartmentsAsync()
    {
        var result = await departmentRepository.SearchDepartmentsAsync();
        var mappedData = mapper.Map<List<SearchDepartmentsResponse>>(result);

        return mappedData;
    }

    public async Task<int> UpdateDepartmentAsync(UpdateDepartmentRequest department)
    {
        var mappedData = mapper.Map<Entities.Department>(department);
        var result = await departmentRepository.UpdateDepartmentAsync(mappedData);

        return result;
    }
}