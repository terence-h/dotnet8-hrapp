﻿using AutoMapper;
using Employee.Service.Dtos;

namespace Employee.Service.MappingProfiles;

public class SearchEmployeesResponseProfile : Profile
{
    public SearchEmployeesResponseProfile()
    {
        CreateMap<Entities.Employee, SearchEmployeesResponse>()
            .ForMember(resp => resp.EmpDepId, e => e.MapFrom(e => e.Department.DepartmentId))
            .ForMember(resp => resp.EmpDepName, e => e.MapFrom(e => e.Department.DepartmentName));
            //.ForMember(resp => resp.EmpAddress, e => e.MapFrom((e, resp) =>
            //{
            //    var mAddress = new Address
            //    {
            //        Line1 = e.Address.Line1,
            //        Line2 = e.Address.Line2,
            //        UnitNo = e.Address.UnitNo,
            //        PostalCode = e.Address.PostalCode,
            //        Country = e.Address.Country,
            //        City = e.Address.City,
            //        State = e.Address.State
            //    };
            //    return mAddress;
            //}));
    }
}