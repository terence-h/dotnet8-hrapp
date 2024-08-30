using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Department;
using dotnet8_hrapp_razor.client.Models.Employee;
using dotnet8_hrapp_razor.client.WebApiProxy;
using Employee.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_hrapp_razor.client.Pages.Employee;

public class EditModel(IEmployeeProxy employeeProxy, IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required EmployeeEditModel EmployeeEditModel { get; set; }

    private readonly IEmployeeProxy _employeeProxy = employeeProxy;
    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync(int employeeId)
    {
        var response = await _employeeProxy.GetEmployeeAsync(employeeId);
        EmployeeEditModel = _mapper.Map<EmployeeEditModel>(response);

        var searchDepartmentsResp = await _departmentProxy.SearchDepartmentsAsync();
        DepartmentListModel departmentListModel = _mapper.Map<DepartmentListModel>(searchDepartmentsResp);

        foreach (var department in departmentListModel.Departments)
        {
            EmployeeEditModel.DepartmentSelectList.Add(new(department.Name, department.Id));
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!this.ModelState.IsValid)
        {
            return Page();
        }

        UpdateEmployeeRequest request = _mapper.Map<UpdateEmployeeRequest>(EmployeeEditModel);

        try
        {
            var response = await _employeeProxy.UpdateEmployeeAsync(request.Id, request);
            TempData["EmployeeDetailCallback"] = "Employee changes saved successfully";
            return RedirectToPage("Detail", new { employeeId = response });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}