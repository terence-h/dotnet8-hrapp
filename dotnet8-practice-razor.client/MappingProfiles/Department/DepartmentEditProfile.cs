using AutoMapper;
using dotnet8_practice_razor.client.Models.Department;
using Department.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Department;

public class DepartmentEditProfile : Profile
{
    public DepartmentEditProfile()
    {
        CreateMap<DetailDepartmentResponse, DepartmentEditModel>()
            .ForMember(model => model.Id, e => e.MapFrom(model => model.DepartmentId))
            .ForMember(model => model.Name, e => e.MapFrom(model => model.DepartmentName));

        CreateMap<DepartmentEditModel, UpdateDepartmentRequest>()
            .ForMember(req => req.DepartmentId, e => e.MapFrom(model => model.Id))
            .ForMember(req => req.DepartmentName, e => e.MapFrom(model => model.Name));
    }
}
