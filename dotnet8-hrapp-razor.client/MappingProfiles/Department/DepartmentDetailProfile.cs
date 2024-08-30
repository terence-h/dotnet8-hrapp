using AutoMapper;
using Department.Service.Dtos;
using dotnet8_hrapp_razor.client.Models.Department;

namespace dotnet8_hrapp_razor.client.MappingProfiles.Department;

public class DepartmentDetailProfile : Profile
{
    public DepartmentDetailProfile()
    {
        CreateMap<DetailDepartmentResponse, DepartmentDetailModel>()
            .ForMember(model => model.Id, resp => resp.MapFrom(r => r.DepartmentId))
            .ForMember(model => model.Name, resp => resp.MapFrom(r => r.DepartmentName))
            .ForMember(model => model.Employees, resp => resp.MapFrom((r, model) =>
            {
                var mEmployees = new List<DepartmentDetailModel.EmployeeInfo>();

                foreach (var employee in r.Employees)
                {
                    mEmployees.Add(new DepartmentDetailModel.EmployeeInfo
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary
                    });  
                }
                return mEmployees;
            }));
    }
}
