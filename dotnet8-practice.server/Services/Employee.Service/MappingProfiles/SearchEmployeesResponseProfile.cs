using AutoMapper;
using Employee.Service.Dtos;

namespace Employee.Service.MappingProfiles;

public class SearchEmployeesResponseProfile : Profile
{
    public SearchEmployeesResponseProfile()
    {
        CreateMap<Entities.Employee, SearchEmployeesResponse>()
            .ForMember(resp => resp.DepartmentId, e => e.MapFrom(e => e.Department.DepartmentId))
            .ForMember(resp => resp.DepartmentName, e => e.MapFrom(e => e.Department.DepartmentName));
    }
}
