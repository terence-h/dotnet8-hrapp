using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_hrapp_razor.client.MappingProfiles.Employee;

public class EmployeeCreateProfile : Profile
{
    public EmployeeCreateProfile()
    {
        CreateMap<EmployeeCreateModel, CreateEmployeeRequest>()
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
