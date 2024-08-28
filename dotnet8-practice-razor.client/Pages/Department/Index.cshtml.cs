using AutoMapper;
using dotnet8_practice_razor.client.Models.Department;
using dotnet8_practice_razor.client.WebApiProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_practice_razor.client.Pages.Department;

[ValidateAntiForgeryToken]
public class DepartmentIndexModel(IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required DepartmentListModel DepartmentListModel { get; set; }

    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync()
    {
        var departmentResp = await _departmentProxy.SearchDepartmentsAsync();
        DepartmentListModel = _mapper.Map<DepartmentListModel>(departmentResp, opts =>
        {
            opts.AfterMap((_, model) =>
            {
                foreach(var department in model.Departments)
                {
                    department.EmployeeCount = department.Employees.Count;
                }
            });
        });
    }

    public async Task<IActionResult?> OnPostDeleteAsync(int departmentId)
    {
        if (departmentId == 0)
        {
            return RedirectToPage();
        }

        try
        {
            var response = await _departmentProxy.DeleteDepartmentAsync(departmentId);
            ViewData["DepartmentDeleteSuccess"] = "Department information deleted successfully";
            await OnGetAsync();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}