using Microsoft.AspNetCore.Mvc;

namespace dotnet8_practice_razor.client.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
