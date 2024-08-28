using AutoMapper;
using dotnet8_practice_razor.client.Models.Department;
using Department.Service.Dtos;

namespace dotnet8_practice_razor.client.MappingProfiles.Department;

public class DepartmentListProfile : Profile
{
    public DepartmentListProfile()
    {
        CreateMap<List<SearchDepartmentsResponse>, DepartmentListModel>()
            .ForMember(model => model.Departments, dto => dto.MapFrom((dto, model) =>
            {
                var departments = new List<DepartmentListModel.DepartmentInfo>();

                foreach(var department in dto)
                {
                    var mEmployees = new List<DepartmentListModel.EmployeeInfo>();

                    foreach(var employee in department.Employees)
                    {
                        mEmployees.Add(new DepartmentListModel.EmployeeInfo
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            Salary = employee.Salary,
                            Age = employee.Age,
                            Gender = employee.Gender
                        });
                    }

                    var mDepartment = new DepartmentListModel.DepartmentInfo
                    {
                        Id = department.DepartmentId,
                        Name = department.DepartmentName,
                        Employees = mEmployees
                    };

                    departments.Add(mDepartment);
                }
                return departments;
            }));
    }
}
