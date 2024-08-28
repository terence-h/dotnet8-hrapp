using AutoMapper;
using dotnet8_practice_razor.client.Models.Department;
using dotnet8_practice_razor.client.Models.Employee;
using dotnet8_practice_razor.client.WebApiProxy;
using Employee.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_practice_razor.client.Pages.Employee;

public class CreateModel(IEmployeeProxy employeeProxy, IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required EmployeeCreateModel EmployeeCreateModel { get; set; }

    private readonly IEmployeeProxy _employeeProxy = employeeProxy;
    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync()
    {
        EmployeeCreateModel = new EmployeeCreateModel();

        var searchDepartmentsResp = await _departmentProxy.SearchDepartmentsAsync();
        DepartmentListModel departmentListModel = _mapper.Map<DepartmentListModel>(searchDepartmentsResp);

        EmployeeCreateModel.DepartmentSelectList.Add(new("Please select a department", null));

        foreach (var department in departmentListModel.Departments)
        {
            EmployeeCreateModel.DepartmentSelectList.Add(new(department.Name, department.Id));
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!this.ModelState.IsValid)
        {
            return Page();
        }

        CreateEmployeeRequest request = _mapper.Map<CreateEmployeeRequest>(EmployeeCreateModel);

        try
        {
            var response = await _employeeProxy.CreateEmployeeAsync(request);
            TempData["EmployeeDetailCallback"] = "Employee added successfully";
            return RedirectToPage("Detail", new { employeeId = response });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
