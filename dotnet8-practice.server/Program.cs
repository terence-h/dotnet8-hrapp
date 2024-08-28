using Department.Service.Database;
using Department.Service.Interfaces;
using Department.Service.Repositories;
using Department.Service.Services;
using Employee.Service.Database;
using Employee.Service.Interfaces;
using Employee.Service.Repositories;
using Employee.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("Default");

// Add services to the container.
AddDbContexts();
AddServices();
AddAutoMapper();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(config =>
{
    // use fully qualified object names
    config.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDbContexts()
{
    services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddDbContext<DepartmentDbContext>(options =>
        options.UseSqlServer(connectionString));
}

void AddServices()
{
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    services.AddScoped<IDepartmentService, DepartmentService>();
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
}

void AddAutoMapper()
{
    services.AddAutoMapper(
        typeof(IEmployeeService).Assembly,
        typeof(IDepartmentService).Assembly);
}