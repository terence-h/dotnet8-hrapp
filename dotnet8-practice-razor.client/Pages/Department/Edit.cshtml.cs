using AutoMapper;
using dotnet8_practice_razor.client.Models.Department;
using dotnet8_practice_razor.client.WebApiProxy;
using Department.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet8_practice_razor.client.Pages.Department;

public class EditModel(IDepartmentProxy departmentProxy, IMapper mapper) : PageModel
{
    [BindProperty]
    public required DepartmentEditModel DepartmentEditModel { get; set; }

    private readonly IDepartmentProxy _departmentProxy = departmentProxy;
    private readonly IMapper _mapper = mapper;

    public async Task OnGetAsync(int departmentId)
    {
        var response = await _departmentProxy.GetDepartmentAsync(departmentId);
        DepartmentEditModel = _mapper.Map<DepartmentEditModel>(response);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!this.ModelState.IsValid)
        {
            return Page();
        }

        UpdateDepartmentRequest request = _mapper.Map<UpdateDepartmentRequest>(DepartmentEditModel);

        try
        {
            var response = await _departmentProxy.UpdateDepartmentAsync(request.DepartmentId, request);
            TempData["DepartmentDetailCallback"] = "Department changes saved successfully";
            return RedirectToPage("Detail", new { departmentId = response });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}