﻿using Department.Service.Dtos;
using Department.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet8_hrapp.server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    // GET: api/Department
    [Authorize(Policy = "RequireUser")]
    [HttpGet]
    public async Task<IActionResult> SearchDepartments()
    {
        var result = await departmentService.SearchDepartmentsAsync();

        return Ok(result);
    }

    // GET api/Department/5
    [Authorize(Policy = "RequireUser")]
    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetDepartment(int departmentId)
    {
        var result = await departmentService.GetDepartmentAsync(departmentId);

        return Ok(result);
    }

    // POST api/Department
    [Authorize(Policy = "RequireAdmin")]
    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
    {
        var result = await departmentService.CreateDepartmentAsync(request);

        return Ok(result);
    }

    // PUT api/Department/5
    [Authorize(Policy = "RequireAdmin")]
    [HttpPut("{departmentId}")]
    public async Task<IActionResult> UpdateDepartment(int departmentId, [FromBody] UpdateDepartmentRequest request)
    {
        var result = await departmentService.UpdateDepartmentAsync(request);

        return Ok(result);
    }

    // DELETE api/Department/5
    [Authorize(Policy = "RequireAdmin")]
    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> DeleteDepartment(int departmentId)
    {
        var result = await departmentService.DeleteDepartmentAsync(departmentId);

        return Ok(result);
    }
}
