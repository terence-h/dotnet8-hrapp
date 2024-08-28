using dotnet8_practice_razor.client.Controllers;
using dotnet8_practice_razor.client.MappingProfiles.Employee;
using dotnet8_practice_razor.client.WebApiProxy;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var webApiServerUrl = configuration.GetValue<string>("WebApiServer");
var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
AddRefitClients();
AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

void AddRefitClients()
{
    if (webApiServerUrl == null)
        throw new NullReferenceException("Missing web api server URL");

    services.AddRefitClientWithValidation<IEmployeeProxy>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(webApiServerUrl));

    services.AddRefitClientWithValidation<IDepartmentProxy>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(webApiServerUrl));
}

void AddAutoMapper()
{
    services.AddAutoMapper(typeof(HomeController).Assembly);
}