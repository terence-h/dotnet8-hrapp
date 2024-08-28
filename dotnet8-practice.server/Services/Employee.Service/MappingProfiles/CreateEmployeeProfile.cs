using AutoMapper;
using Employee.Service.Dtos;

namespace Employee.Service.MappingProfiles;

public class CreateEmployeeProfile : Profile
{
    public CreateEmployeeProfile()
    {
        CreateMap<CreateEmployeeRequest, Entities.Employee>()
            //.ForMember(e => e.EmpDepartmentId, req => req.MapFrom(req => req.EmpDepartmentId))
            .ForMember(e => e.Address, req => req.MapFrom((req, e) =>
            {
                var mAddress = new Entities.Address
                {
                    Line1 = req.EmpAddress.Line1,
                    Line2 = req.EmpAddress.Line2,
                    UnitNo = req.EmpAddress.UnitNo,
                    PostalCode = req.EmpAddress.PostalCode,
                    Country = req.EmpAddress.Country,
                    City = req.EmpAddress.City,
                    State = req.EmpAddress.State
                };
                return mAddress;
            }));
    }
}
