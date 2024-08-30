using Employee.Service.Dtos;
using Employee.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnet8_hrapp.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    // GET: api/Employee
    [HttpGet]
    public async Task<IActionResult> SearchEmployees()
    {
        var result = await employeeService.SearchEmployeesAsync();
            
        return Ok(result);
    }

    // GET api/Employee/5
    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployee(int employeeId)
    {
        var result = await employeeService.GetEmployeeAsync(employeeId);

        return Ok(result);
    }

    // POST api/Employee
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
    {
        var result = await employeeService.CreateEmployeeAsync(request);

        return Ok(result);
    }

    // PUT api/Employee/5
    [HttpPut("{employeeId}")]
    public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] UpdateEmployeeRequest request)
    {
        var result = await employeeService.UpdateEmployeeAsync(request);
        return Ok(result);
    }

    // DELETE api/Employee/5
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var result = await employeeService.DeleteEmployeeAsync(employeeId);
        return Ok(result);
    }
}
