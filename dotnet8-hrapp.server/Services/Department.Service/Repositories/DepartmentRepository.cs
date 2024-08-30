using Department.Service.Database;
using Department.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Department.Service.Repositories;

public class DepartmentRepository(DepartmentDbContext dbContext) : IDepartmentRepository
{
    public async Task<int> CreateDepartmentAsync(Entities.Department department)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            dbContext.Departments.Add(department);
            await dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return department.DepartmentId;
    }

    public async Task<int> DeleteDepartmentAsync(int departmentId)
    {
        var employee = dbContext.Departments.Where(e => e.DepartmentId == departmentId) ?? throw new NullReferenceException("Department ID does not exist!");
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            await employee.ExecuteDeleteAsync();
            transaction.Commit();
        }
        return departmentId;
    }

    public async Task<Entities.Department> GetDepartmentAsync(int departmentId)
    {
        var department = await dbContext.Departments
            .AsNoTracking()
            .Include(e => e.Employees)
            .SingleOrDefaultAsync(e => e.DepartmentId == departmentId)
            ?? throw new NullReferenceException($"Department ID {departmentId} does not exist!");

        return department;
    }

    public async Task<List<Entities.Department>> SearchDepartmentsAsync()
    {
        var departments = await dbContext.Departments
            .AsNoTracking()
            .Include(e => e.Employees)
            .ToListAsync();

        return departments;
    }

    public async Task<int> UpdateDepartmentAsync(Entities.Department department)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            dbContext.Departments.Update(department);
            await dbContext.SaveChangesAsync();
            transaction.Commit();
        }
        return department.DepartmentId;
    }
}