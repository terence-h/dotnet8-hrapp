using System.Text;
using Account.Service.Data;
using Account.Service.Database;
using Account.Service.Entities;
using Account.Service.Interfaces;
using Account.Service.Services;
using Department.Service.Database;
using Department.Service.Interfaces;
using Department.Service.Repositories;
using Department.Service.Services;
using Employee.Service.Database;
using Employee.Service.Interfaces;
using Employee.Service.Repositories;
using Employee.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("Default");

// Add services to the container.
AddDbContexts();
AddServices();
AddAutoMapper();
AddAuthentication();

services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(config =>
{
    // use fully qualified object names
    config.CustomSchemaIds(x => x.FullName);
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AddCors();

app.UseHttpsRedirection();

// Order matters and must be before map controllers
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
SeedDataOnFirstRun(scope.ServiceProvider);

app.Run();

void AddDbContexts()
{
    services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddDbContext<DepartmentDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddDbContext<AccountDbContext>(options =>
        options.UseSqlServer(connectionString));
}

void AddServices()
{
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();

    services.AddScoped<IDepartmentService, DepartmentService>();
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();

    services.AddScoped<ITokenService, TokenService>();
}

void AddAutoMapper()
{
    services.AddAutoMapper(
        typeof(IEmployeeService).Assembly,
        typeof(IDepartmentService).Assembly,
        typeof(ITokenService).Assembly);
}

void AddCors()
{
    services.AddCors();
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                    .WithOrigins("http://localhost:4200", "https://localhost:4200"));
}

void AddAuthentication()
{
    services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
        })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<AccountDbContext>();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenKey = configuration["TokenKey"] ?? throw new Exception("Token key not found");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    services.AddAuthorizationBuilder()
            .AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"))
            .AddPolicy("RequireUser", policy => policy.RequireRole("Admin", "User"));
}

async void SeedDataOnFirstRun(IServiceProvider service)
{
    try
    {
        var accountDbContext = service.GetRequiredService<AccountDbContext>();
        var employeeDbContext = service.GetRequiredService<EmployeeDbContext>();
        var userManager = service.GetRequiredService<UserManager<User>>();
        var roleManager = service.GetRequiredService<RoleManager<Role>>();
        await accountDbContext.Database.MigrateAsync();
        await employeeDbContext.Database.MigrateAsync();
        await DataSeed.SeedDefaultAccountsAndRoles(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = service.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during database migration.");
    }
}