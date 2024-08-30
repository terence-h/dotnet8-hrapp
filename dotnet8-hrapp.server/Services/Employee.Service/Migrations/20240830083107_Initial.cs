using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _Employee.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_DEPARTMENT",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DEPARTMENT_DEPARTMENT_ID", x => x.DEPARTMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_EMPLOYEE",
                columns: table => new
                {
                    EMP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    EMP_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMP_SALARY = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EMP_GENDER = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EMP_DATE_OF_BIRTH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMP_CONTACT_COUNTRY_CODE = table.Column<int>(type: "int", nullable: false),
                    EMP_CONTACT_NO = table.Column<int>(type: "int", nullable: false),
                    EMP_DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EMP_ADDRESS_CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMP_ADDRESS_COUNTRY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMP_ADDRESS_LINE_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMP_ADDRESS_LINE_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMP_ADDRESS_POSTAL_CODE = table.Column<int>(type: "int", nullable: false),
                    EMP_ADDRESS_STATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMP_ADDRESS_UNIT_NO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EMPLOYEE_EMPLOYEE_ID", x => x.EMP_ID);
                    table.ForeignKey(
                        name: "FK_T_EMPLOYEE_T_DEPARTMENT_EMP_DEPARTMENT_ID",
                        column: x => x.EMP_DEPARTMENT_ID,
                        principalTable: "T_DEPARTMENT",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_EMPLOYEE_EMP_DEPARTMENT_ID",
                table: "T_EMPLOYEE",
                column: "EMP_DEPARTMENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_EMPLOYEE");

            migrationBuilder.DropTable(
                name: "T_DEPARTMENT");
        }
    }
}
