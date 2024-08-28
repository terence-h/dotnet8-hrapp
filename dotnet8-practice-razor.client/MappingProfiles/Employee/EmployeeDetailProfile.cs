using AutoMapper;
using dotnet8_practice_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Employee;

public class EmployeeDetailProfile : Profile
{
    public EmployeeDetailProfile()
    {
        CreateMap<DetailEmployeeResponse, EmployeeDetailModel>()
            .ForMember(model => model.Age, e => e.MapFrom((e, model) =>
            {
                DateTime today = DateTime.Today;

                int age = today.Year - e.DateOfBirth.Year;

                // Adjust age if the birthdate has not occurred yet this year
                if (today < e.DateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }))
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
