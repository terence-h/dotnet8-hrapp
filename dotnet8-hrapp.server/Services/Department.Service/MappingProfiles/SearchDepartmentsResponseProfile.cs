using AutoMapper;
using Department.Service.Dtos;

namespace Department.Service.MappingProfiles;

public class SearchDepartmentsResponseProfile : Profile
{
    public SearchDepartmentsResponseProfile()
    {
        CreateMap<Entities.Department, SearchDepartmentsResponse>()
            //.ForMember(resp => resp.DepartmentId, e => e.MapFrom(e => e.DepartmentId))
            //.ForMember(resp => resp.DepartmentName, e => e.MapFrom(e => e.DepartmentName))
            .ForMember(resp => resp.Employees, e => e.MapFrom((e, resp) =>
            {
                var mEmployees = new List<SearchDepartmentsResponse.Employee>();

                foreach(var employee in e.Employees)
                {
                    mEmployees.Add(new SearchDepartmentsResponse.Employee
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DateOfBirth = employee.DateOfBirth,
                        Gender = employee.Gender
                    });
                }
                return mEmployees;
            }));
    }
}
