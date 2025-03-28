using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services;

public class EmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        employee.Name = updatedEmployee.Name;
        employee.RoomNumber = updatedEmployee.RoomNumber;
        employee.Department = updatedEmployee.Department;
        employee.ComputerInfo = updatedEmployee.ComputerInfo;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}