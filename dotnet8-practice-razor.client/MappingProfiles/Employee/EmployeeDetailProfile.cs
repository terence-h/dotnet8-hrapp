using AutoMapper;
using dotnet8_practice_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Employee;

public class EmployeeDetailProfile : Profile
{
    public EmployeeDetailProfile()
    {
        CreateMap<DetailEmployeeResponse, EmployeeDetailModel>()
            .ForMember(model => model.Id, e => e.MapFrom(e => e.EmpId))
            .ForMember(model => model.Name, e => e.MapFrom(e => e.EmpName))
            .ForMember(model => model.Salary, e => e.MapFrom(e => e.EmpSalary))
            .ForMember(model => model.Gender, e => e.MapFrom(e => e.EmpGender))
            .ForMember(model => model.Age, e => e.MapFrom(e => e.EmpAge))
            .ForMember(model => model.ContactCountryCode, e => e.MapFrom(e => e.EmpContactCountryCode))
            .ForMember(model => model.ContactNo, e => e.MapFrom(e => e.EmpContactNo))
            .ForMember(model => model.DepartmentId, e => e.MapFrom(e => e.EmpDepId))
            .ForMember(model => model.DepartmentName, e => e.MapFrom(e => e.EmpDepName))
            .ForMember(model => model.Address, e => e.MapFrom((e, model) =>
            {
                var mAddress = new EmployeeDetailModel.AddressInfo
                {
                    Line1 = e.EmpAddress.Line1,
                    Line2 = e.EmpAddress.Line2,
                    UnitNo = e.EmpAddress.UnitNo,
                    City = e.EmpAddress.City,
                    State = e.EmpAddress.State,
                    Country = e.EmpAddress.Country,
                    PostalCode = e.EmpAddress.PostalCode
                };
                return mAddress;
            }));
    }
}
