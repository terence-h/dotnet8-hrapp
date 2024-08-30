using AutoMapper;
using Department.Service.Dtos;
using Department.Service.Interfaces;

namespace Department.Service.Services;

public class DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> CreateDepartmentAsync(CreateDepartmentRequest department)
    {
        var mappedData = _mapper.Map<Entities.Department>(department);
        var result = await _departmentRepository.CreateDepartmentAsync(mappedData);

        return result;
    }

    public async Task<int> DeleteDepartmentAsync(int departmentId)
    {
        var result = await _departmentRepository.DeleteDepartmentAsync(departmentId);

        return result;
    }

    public async Task<DetailDepartmentResponse> GetDepartmentAsync(int departmentId)
    {
        var result = await _departmentRepository.GetDepartmentAsync(departmentId);
        var mappedData = _mapper.Map<DetailDepartmentResponse>(result);

        return mappedData;
    }

    public async Task<List<SearchDepartmentsResponse>> SearchDepartmentsAsync()
    {
        var result = await _departmentRepository.SearchDepartmentsAsync();
        var mappedData = _mapper.Map<List<SearchDepartmentsResponse>>(result);

        return mappedData;
    }

    public async Task<int> UpdateDepartmentAsync(UpdateDepartmentRequest department)
    {
        var mappedData = _mapper.Map<Entities.Department>(department);
        var result = await _departmentRepository.UpdateDepartmentAsync(mappedData);

        return result;
    }
}