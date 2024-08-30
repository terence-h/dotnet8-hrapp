using AutoMapper;
using Department.Service.Dtos;

namespace Department.Service.MappingProfiles;

public class UpdateDepartmentProfile : Profile
{
    public UpdateDepartmentProfile()
    {
        CreateMap<UpdateDepartmentRequest, Entities.Department>();
    }
}
