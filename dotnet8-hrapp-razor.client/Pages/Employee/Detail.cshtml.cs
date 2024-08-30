using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Employee;
using dotnet8_hrapp_razor.client.WebApiProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_hrapp_razor.client.Pages.Employee;

public class DetailModel (IEmployeeProxy employeeProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required EmployeeDetailModel EmployeeDetailModel { get; set; }

    private readonly IEmployeeProxy _employeeProxy = employeeProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync(int employeeId)
    {
        var employeeResp = await _employeeProxy.GetEmployeeAsync(employeeId);
        EmployeeDetailModel = _mapper.Map<EmployeeDetailModel>(employeeResp);
    }
}
