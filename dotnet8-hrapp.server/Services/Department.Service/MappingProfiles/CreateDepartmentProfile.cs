using AutoMapper;
using Department.Service.Dtos;

namespace Department.Service.MappingProfiles;

public class CreateDepartmentProfile : Profile
{
    public CreateDepartmentProfile()
    {
        CreateMap<CreateDepartmentRequest, Entities.Department>();
    }
}
