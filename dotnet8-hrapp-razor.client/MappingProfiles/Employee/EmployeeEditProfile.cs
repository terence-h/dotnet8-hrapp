using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_hrapp_razor.client.MappingProfiles.Employee;

public class EmployeeEditProfile : Profile
{
    public EmployeeEditProfile()
    {
        CreateMap<DetailEmployeeResponse, EmployeeEditModel>()
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
