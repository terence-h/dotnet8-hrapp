using AutoMapper;
using dotnet8_practice_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Employee;

public class EmployeeCreateProfile : Profile
{
    public EmployeeCreateProfile()
    {
        CreateMap<EmployeeCreateModel, CreateEmployeeRequest>()
            .ForMember(req => req.EmpName, e => e.MapFrom(model => model.Name))
            .ForMember(req => req.EmpSalary, e => e.MapFrom(model => model.Salary))
            .ForMember(req => req.EmpGender, e => e.MapFrom(model => model.Gender))
            .ForMember(req => req.EmpAge, e => e.MapFrom(model => model.Age))
            .ForMember(req => req.EmpContactCountryCode, e => e.MapFrom(model => model.ContactCountryCode))
            .ForMember(req => req.EmpContactNo, e => e.MapFrom(model => model.ContactNo))
            .ForMember(req => req.EmpDepartmentId, e => e.MapFrom(model => model.DepartmentId))
            .ForMember(req => req.EmpAddress, e => e.MapFrom((e, req) =>
            {
                var reqAddress = new CreateEmployeeRequest.Address
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
