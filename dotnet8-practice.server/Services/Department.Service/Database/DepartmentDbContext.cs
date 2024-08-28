using Microsoft.EntityFrameworkCore;

namespace Department.Service.Database;

public class DepartmentDbContext : DbContext
{
    public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Entities.Employee>(entity =>
        {
            entity.ToTable("T_EMPLOYEE");

            entity.HasKey(e => e.Id).HasName("PK_T_EMPLOYEE_EMPLOYEE_ID");

            entity.Property(e => e.Id)
                .HasColumnName("EMP_ID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("EMP_NAME");

            entity.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("EMP_SALARY");

            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("EMP_GENDER");

            entity.Property(e => e.DateOfBirth)
                .IsRequired()
                .HasColumnName("EMP_DATE_OF_BIRTH");

            entity.Property(e => e.ContactCountryCode)
                .IsRequired()
                .HasColumnName("EMP_CONTACT_COUNTRY_CODE");

            entity.Property(e => e.ContactNo)
                .IsRequired()
                .HasColumnName("EMP_CONTACT_NO");

            entity.Property(e => e.DepartmentId)
                .IsRequired()
                .HasColumnName("EMP_DEPARTMENT_ID");

            entity.ComplexProperty(e => e.Address);
        });
    }
}
