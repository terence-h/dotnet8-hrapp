using AutoMapper;
using Department.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Service.MappingProfiles;

public class DetailDepartmentResponseProfile : Profile
{
    public DetailDepartmentResponseProfile()
    {
        CreateMap<Entities.Department, DetailDepartmentResponse>()
            .ForMember(resp => resp.Employees, e => e.MapFrom((e, resp) =>
            {
                var mEmployees = new List<DetailDepartmentResponse.Employee>();

                foreach (var employee in e.Employees)
                {
                    mEmployees.Add(new DetailDepartmentResponse.Employee
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Salary = employee.Salary,
                        DateOfBirth = employee.DateOfBirth,
                        Gender = employee.Gender
                    });
                }
                
                return mEmployees;
            }));
    }
}
