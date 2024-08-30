using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Employee;
using dotnet8_hrapp_razor.client.WebApiProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_hrapp_razor.client.Pages.Employee;

[ValidateAntiForgeryToken]
public class EmployeeIndexModel(IEmployeeProxy employeeProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required EmployeeListModel EmployeeListModel { get; set; }

    private readonly IEmployeeProxy _employeeProxy = employeeProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync()
    {
        var employeeResp = await _employeeProxy.SearchEmployeesAsync();
        EmployeeListModel = _mapper.Map<EmployeeListModel>(employeeResp);
    }

    public async Task<IActionResult?> OnPostDeleteAsync(int employeeId)
    {
        if (employeeId == 0)
        {
            return RedirectToPage();
        }

        try
        {
            var response = await _employeeProxy.DeleteEmployeeAsync(employeeId);
            ViewData["EmployeeDeleteSuccess"] = "Employee information deleted successfully";
            await OnGetAsync();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}