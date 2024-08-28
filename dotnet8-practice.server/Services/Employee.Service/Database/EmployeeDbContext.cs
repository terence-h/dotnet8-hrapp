using Employee.Service.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Employee.Service.Database;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Employee>(entity =>
        {
            entity.ToTable("T_EMPLOYEE");

            entity.HasKey(e => e.EmpId).HasName("PK_T_EMPLOYEE_EMPLOYEE_ID");

            entity.Property(e => e.EmpId)
                .HasColumnName("EMPLOYEE_ID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.EmpName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("EMPLOYEE_NAME");

            entity.Property(e => e.EmpSalary)
                .IsRequired()
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("EMPLOYEE_SALARY");

            entity.Property(e => e.EmpGender)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("EMPLOYEE_GENDER");

            entity.Property(e => e.EmpAge)
                .IsRequired()
                .HasColumnName("EMPLOYEE_AGE");

            entity.Property(e => e.EmpContactCountryCode)
                .IsRequired()
                .HasColumnName("EMPLOYEE_CONTACT_COUNTRY_CODE");

            entity.Property(e => e.EmpContactNo)
                .IsRequired()
                .HasColumnName("EMPLOYEE_CONTACT_NO");

            entity.Property(e => e.EmpDepartmentId)
                .IsRequired()
                .HasColumnName("EMPLOYEE_DEPARTMENT_ID");

            entity.ComplexProperty(e => e.Address);
        });

        modelBuilder.Entity<Entities.Department>(entity =>
        {
            entity.ToTable("T_DEPARTMENT");

            entity.HasKey(e => e.DepartmentId).HasName("PK_T_DEPARTMENT_DEPARTMENT_ID");

            entity.Property(e => e.DepartmentId)
                .HasColumnName("DEPARTMENT_ID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DEPARTMENT_NAME");
        });
    }
}