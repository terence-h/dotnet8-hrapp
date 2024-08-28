using Department.Service.Dtos;
using Department.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet8_practice.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    private readonly IDepartmentService _departmentService = departmentService;

    // GET: api/Department
    [HttpGet]
    public async Task<IActionResult> SearchDepartments()
    {
        var result = await _departmentService.SearchDepartmentsAsync();

        return Ok(result);
    }

    // GET api/Department/5
    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetDepartment(int departmentId)
    {
        var result = await _departmentService.GetDepartmentAsync(departmentId);

        return Ok(result);
    }

    // POST api/Department
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var result = await _departmentService.CreateDepartmentAsync(request);

        return Ok(result);
    }

    // PUT api/Department/5
    [HttpPut("{departmentId}")]
    public async Task<IActionResult> UpdateDepartment(int departmentId, [FromBody] UpdateDepartmentRequest request)
    {
        var result = await _departmentService.UpdateDepartmentAsync(request);

        return Ok(result);
    }

    // DELETE api/Department/5
    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> DeleteDepartment(int departmentId)
    {
        var result = await _departmentService.DeleteDepartmentAsync(departmentId);

        return Ok(result);
    }
}
