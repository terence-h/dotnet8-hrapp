using AutoMapper;
using dotnet8_hrapp_razor.client.Models.Department;
using dotnet8_hrapp_razor.client.WebApiProxy;
using Department.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_hrapp_razor.client.Pages.Department;

public class CreateModel(IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required DepartmentCreateModel DepartmentCreateModel { get; set; }

    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!this.ModelState.IsValid)
        {
            return Page();
        }

        CreateDepartmentRequest request = _mapper.Map<CreateDepartmentRequest>(DepartmentCreateModel);

        try
        {
            var response = await _departmentProxy.CreateDepartmentAsync(request);
            TempData["DepartmentDetailCallback"] = "Department added successfully";
            return RedirectToPage("Detail", new { departmentId = response });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}