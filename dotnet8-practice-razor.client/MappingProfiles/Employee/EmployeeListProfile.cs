using AutoMapper;
using dotnet8_practice_razor.client.Models.Employee;
using Employee.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Employee;

public class EmployeeListProfile : Profile
{
    public EmployeeListProfile()
    {
        CreateMap<List<SearchEmployeesResponse>, EmployeeListModel>()
            .ForMember(model => model.Employees, dto => dto.MapFrom((dto, model) =>
            {
                var employees = new List<EmployeeListModel.EmployeeInfo>();

                foreach(var employee in dto)
                {
                    //var mAddress = new EmployeeListModel.Address
                    //{
                    //    Line1 = employee.EmpAddress.Line1,
                    //    Line2 = employee.EmpAddress.Line2,
                    //    UnitNo = employee.EmpAddress.UnitNo,
                    //    PostalCode = employee.EmpAddress.PostalCode,
                    //    Country = employee.EmpAddress.Country,
                    //    City = employee.EmpAddress.City,
                    //    State = employee.EmpAddress.State
                    //};

                    var mEmployee = new EmployeeListModel.EmployeeInfo
                    {
                        Id = employee.EmpId,
                        Name = employee.EmpName,
                        Salary = employee.EmpSalary,
                        Age = employee.EmpAge,
                        Gender = employee.EmpGender,
                        DepartmentId = employee.EmpDepId,
                        DepartmentName = employee.EmpDepName,
                        //Address = mAddress
                    };

                    employees.Add(mEmployee);
                }
                return employees;
            }));
    }
}
