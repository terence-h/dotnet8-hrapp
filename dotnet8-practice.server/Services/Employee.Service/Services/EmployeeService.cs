using AutoMapper;
using Employee.Service.Dtos;
using Employee.Service.Interfaces;

namespace Employee.Service.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> CreateEmployeeAsync(CreateEmployeeRequest employee)
    {
        var mappedData = _mapper.Map<Entities.Employee>(employee);
        var result = await _employeeRepository.CreateEmployeeAsync(mappedData);

        return result;
    }

    public async Task<int> DeleteEmployeeAsync(int employeeId)
    {
        var result = await _employeeRepository.DeleteEmployeeAsync(employeeId);

        return result;
    }

    public async Task<DetailEmployeeResponse> GetEmployeeAsync(int employeeId)
    {
        var result = await _employeeRepository.GetEmployeeAsync(employeeId);
        var mappedData = _mapper.Map<DetailEmployeeResponse>(result);

        return mappedData;
    }

    public async Task<List<SearchEmployeesResponse>> SearchEmployeesAsync()
    {
        var result = await _employeeRepository.SearchEmployeesAsync();
        var mappedData = _mapper.Map<List<SearchEmployeesResponse>>(result);

        return mappedData;
    }

    public async Task<int> UpdateEmployeeAsync(UpdateEmployeeRequest employee)
    {
        var mappedData = _mapper.Map<Entities.Employee>(employee);
        var result = await _employeeRepository.UpdateEmployeeAsync(mappedData);

        return result;
    }
}
