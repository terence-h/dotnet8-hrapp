using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_hrapp_razor.client.MappingProfiles.Employee;

public class EmployeeListProfile : Profile
{
    public EmployeeListProfile()
    {
        CreateMap<List<SearchEmployeesResponse>, EmployeeListModel>()
            .ForMember(model => model.Employees, dto => dto.MapFrom((dto, model) =>
            {
                var employees = new List<EmployeeListModel.EmployeeInfo>();

                foreach(var employee in dto)
                {
                    var mEmployee = new EmployeeListModel.EmployeeInfo
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        DepartmentName = employee.DepartmentName,
                    };

                    employees.Add(mEmployee);
                }
                return employees;
            }));
    }
}
