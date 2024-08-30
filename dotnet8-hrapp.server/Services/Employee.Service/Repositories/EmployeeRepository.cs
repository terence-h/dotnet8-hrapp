using Employee.Service.Database;
using Employee.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Service.Repositories;

public class EmployeeRepository(EmployeeDbContext dbContext) : IEmployeeRepository
{
    private readonly EmployeeDbContext _dbContext = dbContext;

    public async Task<int> CreateEmployeeAsync(Entities.Employee employee)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return employee.Id;
    }

    public async Task<int> DeleteEmployeeAsync(int employeeId)
    {
        var employee = _dbContext.Employees.Where(e => e.Id == employeeId) ?? throw new NullReferenceException("Employee ID does not exist!");
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            await employee.ExecuteDeleteAsync();
            transaction.Commit();
        }
        return employeeId;
    }

    public async Task<Entities.Employee> GetEmployeeAsync(int employeeId)
    {
        var employee = await _dbContext.Employees
            .AsNoTracking()
            .Include(e => e.Department)
            .SingleOrDefaultAsync(e => e.Id == employeeId)
            ?? throw new NullReferenceException($"Employee ID {employeeId} does not exist!");

        return employee;
    }

    public async Task<List<Entities.Employee>> SearchEmployeesAsync()
    {
        var employees = await _dbContext.Employees.AsNoTracking().Include(e => e.Department).ToListAsync();

        return employees;
    }

    public async Task<int> UpdateEmployeeAsync(Entities.Employee employee)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return employee.Id;
    }
}