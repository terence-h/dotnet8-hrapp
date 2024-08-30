using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Department;
using dotnet8_hrapp_razor.client.WebApiProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_hrapp_razor.client.Pages.Department;

public class DetailModel(IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required DepartmentDetailModel DepartmentDetailModel { get; set; }

    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync(int departmentId)
    {
        var response = await _departmentProxy.GetDepartmentAsync(departmentId);
        DepartmentDetailModel = _mapper.Map<DepartmentDetailModel>(response);
        DepartmentDetailModel.EmployeeCount = DepartmentDetailModel.Employees.Count;

        foreach (var employee in DepartmentDetailModel.Employees)
        {
            DepartmentDetailModel.TotalSalary += employee.Salary;
        }

        if (DepartmentDetailModel.EmployeeCount > 0)
        {
            DepartmentDetailModel.AverageSalary = DepartmentDetailModel.TotalSalary / DepartmentDetailModel.EmployeeCount;
        }
    }
}