﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Employee.Service.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _Employee.Service.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee.Service.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DEPARTMENT_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DEPARTMENT_NAME");

                    b.HasKey("DepartmentId")
                        .HasName("PK_T_DEPARTMENT_DEPARTMENT_ID");

                    b.ToTable("T_DEPARTMENT", (string)null);
                });

            modelBuilder.Entity("Employee.Service.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EMP_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 100L);

                    b.Property<int>("ContactCountryCode")
                        .HasColumnType("int")
                        .HasColumnName("EMP_CONTACT_COUNTRY_CODE");

                    b.Property<int>("ContactNo")
                        .HasColumnType("int")
                        .HasColumnName("EMP_CONTACT_NO");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("EMP_DATE_OF_BIRTH");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("EMP_DEPARTMENT_ID");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("EMP_GENDER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMP_NAME");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("EMP_SALARY");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Employee.Service.Entities.Employee.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_CITY");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_COUNTRY");

                            b1.Property<string>("Line1")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_LINE_1");

                            b1.Property<string>("Line2")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_LINE_2");

                            b1.Property<int>("PostalCode")
                                .HasColumnType("int")
                                .HasColumnName("EMP_ADDRESS_POSTAL_CODE");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_STATE");

                            b1.Property<string>("UnitNo")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EMP_ADDRESS_UNIT_NO");
                        });

                    b.HasKey("Id")
                        .HasName("PK_T_EMPLOYEE_EMPLOYEE_ID");

                    b.HasIndex("DepartmentId");

                    b.ToTable("T_EMPLOYEE", (string)null);
                });

            modelBuilder.Entity("Employee.Service.Entities.Employee", b =>
                {
                    b.HasOne("Employee.Service.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}