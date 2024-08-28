using AutoMapper;
using dotnet8_practice_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Employee;

public class EmployeeEditProfile : Profile
{
    public EmployeeEditProfile()
    {
        CreateMap<DetailEmployeeResponse, EmployeeEditModel>()
            .ForMember(model => model.Id, e => e.MapFrom(e => e.EmpId))
            .ForMember(model => model.Name, e => e.MapFrom(e => e.EmpName))
            .ForMember(model => model.Salary, e => e.MapFrom(e => e.EmpSalary))
            .ForMember(model => model.Gender, e => e.MapFrom(e => e.EmpGender))
            .ForMember(model => model.Age, e => e.MapFrom(e => e.EmpAge))
            .ForMember(model => model.ContactCountryCode, e => e.MapFrom(e => e.EmpContactCountryCode))
            .ForMember(model => model.ContactNo, e => e.MapFrom(e => e.EmpContactNo))
            .ForMember(model => model.DepartmentId, e => e.MapFrom(e => e.EmpDepId))
            .ForMember(model => model.Address, e => e.MapFrom((e, model) =>
            {
                var mAddress = new EmployeeEditModel.AddressInfo
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

        CreateMap<EmployeeEditModel, UpdateEmployeeRequest>()
            .ForMember(req => req.EmpId, e => e.MapFrom(model => model.Id))
            .ForMember(req => req.EmpName, e => e.MapFrom(model => model.Name))
            .ForMember(req => req.EmpSalary, e => e.MapFrom(model => model.Salary))
            .ForMember(req => req.EmpGender, e => e.MapFrom(model => model.Gender))
            .ForMember(req => req.EmpAge, e => e.MapFrom(model => model.Age))
            .ForMember(req => req.EmpContactCountryCode, e => e.MapFrom(model => model.ContactCountryCode))
            .ForMember(req => req.EmpContactNo, e => e.MapFrom(model => model.ContactNo))
            .ForMember(req => req.EmpDepartmentId, e => e.MapFrom(model => model.DepartmentId))
            .ForMember(req => req.EmpAddress, e => e.MapFrom((e, req) =>
            {
                var reqAddress = new UpdateEmployeeRequest.Address
                {
                    Line1 = e.Address.Line1,
                    Line2 = e.Address.Line2,
                    UnitNo = e.Address.UnitNo,
                    City = e.Address.City,
                    State = e.Address.State,
                    Country = e.Address.Country,
                    PostalCode = e.Address.PostalCode
                };
                return reqAddress;
            }));
    }
}
