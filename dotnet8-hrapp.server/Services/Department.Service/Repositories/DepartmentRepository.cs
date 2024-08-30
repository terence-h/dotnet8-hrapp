using Department.Service.Database;
using Department.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Department.Service.Repositories;

public class DepartmentRepository(DepartmentDbContext dbContext) : IDepartmentRepository
{
    private readonly DepartmentDbContext _dbContext = dbContext;

    public async Task<int> CreateDepartmentAsync(Entities.Department department)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return department.DepartmentId;
    }

    public async Task<int> DeleteDepartmentAsync(int departmentId)
    {
        var employee = _dbContext.Departments.Where(e => e.DepartmentId == departmentId) ?? throw new NullReferenceException("Department ID does not exist!");
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            await employee.ExecuteDeleteAsync();
            transaction.Commit();
        }
        return departmentId;
    }

    public async Task<Entities.Department> GetDepartmentAsync(int departmentId)
    {
        var department = await _dbContext.Departments
            .AsNoTracking()
            .Include(e => e.Employees)
            .SingleOrDefaultAsync(e => e.DepartmentId == departmentId)
            ?? throw new NullReferenceException($"Department ID {departmentId} does not exist!");

        return department;
    }

    public async Task<List<Entities.Department>> SearchDepartmentsAsync()
    {
        var departments = await _dbContext.Departments
            .AsNoTracking()
            .Include(e => e.Employees)
            .ToListAsync();

        return departments;
    }

    public async Task<int> UpdateDepartmentAsync(Entities.Department department)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return department.DepartmentId;
    }
}