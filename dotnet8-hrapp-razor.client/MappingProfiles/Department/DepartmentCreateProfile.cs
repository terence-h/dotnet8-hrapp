﻿using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Department;
using Department.Service.Dtos;

namespace dotnet8_hrapp_razor.client.MappingProfiles.Department;

public class DepartmentCreateProfile : Profile
{
    public DepartmentCreateProfile()
    {
        CreateMap<DepartmentCreateModel, CreateDepartmentRequest>()
            .ForMember(req => req.DepartmentName, e => e.MapFrom(model => model.Name));
    }
}
