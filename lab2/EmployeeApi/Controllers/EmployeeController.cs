using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Services;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetEmployees()
    {
        return Ok(await _employeeService.GetEmployees());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        return employee != null ? Ok(employee) : NotFound(new { message = "Employee not found" });
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
    {
        var createdEmployee = await _employeeService.CreateEmployee(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
    {
        if (!await _employeeService.UpdateEmployee(id, updatedEmployee))
            return NotFound(new { message = "Employee not found" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        if (!await _employeeService.DeleteEmployee(id))
            return NotFound(new { message = "Employee not found" });

        return NoContent();
    }
}